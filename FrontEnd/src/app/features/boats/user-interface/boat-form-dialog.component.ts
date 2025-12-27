import { AbstractControl, FormBuilder, Validators } from '@angular/forms'
import { Component, ElementRef, Inject, Renderer2, ViewChild } from '@angular/core'
import { DateAdapter } from '@angular/material/core'
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog'
import { MatAutocompleteTrigger } from '@angular/material/autocomplete'
import { MatTabGroup } from '@angular/material/tabs'
import { Observable, map, startWith } from 'rxjs'
// Custom
import { BoatHttpService } from '../classes/services/boat-http.service'
import { BoatWriteDto } from '../classes/dtos/boat-write-dto'
import { ButtonClickService } from 'src/app/shared/services/button-click.service'
import { CryptoService } from 'src/app/shared/services/crypto.service'
import { DateHelperService } from 'src/app/shared/services/date-helper.service'
import { DexieService } from 'src/app/shared/services/dexie.service'
import { DialogService } from 'src/app/shared/services/modal-dialog.service'
import { HelperService } from 'src/app/shared/services/helper.service'
import { InputTabStopDirective } from 'src/app/shared/directives/input-tabstop.directive'
import { KeyboardShortcuts, Unlisten } from 'src/app/shared/services/keyboard-shortcuts.service'
import { LocalStorageService } from 'src/app/shared/services/local-storage.service'
import { MessageDialogService } from 'src/app/shared/services/message-dialog.service'
import { MessageInputHintService } from 'src/app/shared/services/message-input-hint.service'
import { MessageLabelService } from 'src/app/shared/services/message-label.service'
import { SessionStorageService } from 'src/app/shared/services/session-storage.service'
import { SimpleEntity } from 'src/app/shared/classes/simple-entity'
import { ValidationService } from 'src/app/shared/services/validation.service'

@Component({
    selector: 'boat-form-dialog.component',
    standalone: false,
    styleUrls: ['./boat-form-dialog.component.css'],
    templateUrl: './boat-form-dialog.component.html'
})

export class BoatFormDialogComponent {

    //#region form

    form = this.formBuilder.group({
        id: 0,
        description: ['', [Validators.required, Validators.maxLength(100)]],
        boatUsage: ['', [Validators.required, ValidationService.RequireAutocomplete]],
        hullType: ['', [Validators.required, ValidationService.RequireAutocomplete]],
        nationality: ['', [Validators.required, ValidationService.RequireAutocomplete]],
        loa: ['', [Validators.required, Validators.min(0), Validators.max(99.99)]],
        beam: ['', [Validators.required, Validators.min(0), Validators.max(9.99)]],
        draft: ['', [Validators.required, Validators.min(0), Validators.max(9.99)]],
        registryPort: ['', [Validators.maxLength(50)]],
        registryNo: ['', [Validators.maxLength(20)]],
        insurance: this.formBuilder.group({
            id: 0,
            boatId: 0,
            company: ['', [Validators.maxLength(100)]],
            contractNo: ['', [Validators.maxLength(50)]],
            expireDate: ''
        }),
        fishingLicence: this.formBuilder.group({
            id: 0,
            boatId: 0,
            issuingAuthority: ['', [Validators.maxLength(100)]],
            licenceNo: ['', [Validators.maxLength(50)]],
            expireDate: ''
        }),
        isAthenian: false,
        isFishingBoat: false,
        isActive: true,
        postAt: '',
        postUser: '',
        putAt: '',
        putUser: ''
    })

    //#endregion

    //#region variables

    @ViewChild('tabGroup') private tabGroup: MatTabGroup

    private isApiBusy = false
    private unlisten: Unlisten
    public feature = 'boatForm'
    public featureIcon = 'boat'
    public icon = 'arrow_back'
    public input: InputTabStopDirective
    public selectedTabIndex = 0

    //#endregion

    //#region autocompletes

    public isAutoCompleteDisabled = true
    public dropdownBoatUsages: Observable<SimpleEntity[]>
    public dropdownHullTypes: Observable<SimpleEntity[]>
    public dropdownNationalities: Observable<SimpleEntity[]>

    //#endregion

    constructor(@Inject(MAT_DIALOG_DATA) public data: any, private boatHttpService: BoatHttpService, private buttonClickService: ButtonClickService, private cryptoService: CryptoService, private dateAdapter: DateAdapter<any>, private dateHelperService: DateHelperService, private dexieService: DexieService, private dialogRef: MatDialogRef<BoatFormDialogComponent>, private dialogService: DialogService, private elementRef: ElementRef, private formBuilder: FormBuilder, private helperService: HelperService, private keyboardShortcutsService: KeyboardShortcuts, private localStorageService: LocalStorageService, private messageDialogService: MessageDialogService, private messageHintService: MessageInputHintService, private messageLabelService: MessageLabelService, private renderer: Renderer2, private sessionStorageService: SessionStorageService) { }

    //#region lifecycle hooks

    ngOnInit(): void {
        this.setLocale()
        this.populateDropdowns()
        if (this.data) { this.populateFieldsFromApi() }
        this.addShortcuts()
    }

    ngAfterViewInit(): void {
        this.addTabIndexToInput()
        this.focusOnField()
    }

    ngOnDestroy(): void {
        this.unlisten()
    }

    //#endregion

    //#region public methods

    public autocompleteFields(fieldName: any, object: any): any {
        return object ? object[fieldName] : undefined
    }

    public checkForEmptyAutoComplete(event: { target: { value: any } }): void {
        if (event.target.value == '') this.isAutoCompleteDisabled = true
    }

    public enableOrDisableAutoComplete(event: any): void {
        this.isAutoCompleteDisabled = this.helperService.enableOrDisableAutoComplete(event)
    }

    public getApiBusyStatus(): boolean {
        return this.isApiBusy
    }

    public getLabel(id: string): string {
        return this.messageLabelService.getDescription(this.feature, id)
    }

    public getHint(id: string, minmax = 0): string {
        return this.messageHintService.getDescription(id, minmax)
    }

    public isAdmin(): boolean {
        return this.cryptoService.decrypt(this.sessionStorageService.getItem('isAdmin')) == 'true' ? true : false
    }

    public isFishingBoat(): boolean {
        return this.form.value.isFishingBoat
    }

    public onClose(): void {
        this.dialogRef.close()
    }

    public onDelete(): void {
        this.dialogService.open(this.messageDialogService.confirmDelete(), 'question', ['abort', 'ok']).subscribe(response => {
            if (response) {
                this.setApiBusyStatus(true)
                this.boatHttpService.delete(this.form.value.id).subscribe({
                    complete: () => {
                        this.deleteFromBrowserStorage()
                        this.closeForm(null, true)
                        this.setApiBusyStatus(false)
                    },
                    error: (errorFromInterceptor) => {
                        this.showErrorFromApi(errorFromInterceptor)
                        this.setApiBusyStatus(false)
                    }
                })
            }
        })
    }

    public onSave(): void {
        this.setApiBusyStatus(true)
        this.saveRecordToApi(this.flattenForm()).then((response) => {
            this.updateBrowserRecordFromApi(response.body)
            this.form.patchValue({
                'id': response.body.id
            })
            this.setApiBusyStatus(false)
        })
    }

    public openOrCloseAutoComplete(trigger: MatAutocompleteTrigger, element: any): void {
        this.helperService.openOrCloseAutocomplete(this.form, element, trigger)
    }

    public tabFocusChange(): void {
        this.addTabIndexToInput()
        this.focusOnField()
    }

    //#endregion

    //#region private methods

    private addShortcuts(): void {
        this.unlisten = this.keyboardShortcutsService.listen({
            'pageUp': (event: KeyboardEvent) => {
                event.preventDefault()
                if (document.getElementsByClassName('cdk-overlay-pane').length === 1) {
                    this.selectedTabIndex > 0 ? this.selectedTabIndex -= 1 : this.selectedTabIndex = this.tabGroup._tabs.length - 1
                    this.addTabIndexToInput()
                    this.focusOnField()
                }
            },
            'pageDown': (event: KeyboardEvent) => {
                event.preventDefault()
                if (document.getElementsByClassName('cdk-overlay-pane').length === 1) {
                    this.selectedTabIndex < this.tabGroup._tabs.length - 1 ? this.selectedTabIndex += 1 : this.selectedTabIndex = 0
                    this.addTabIndexToInput()
                    this.focusOnField()
                }
            },
            'ctrl.s': (event: KeyboardEvent) => {
                event.preventDefault()
                if (document.getElementsByClassName('cdk-overlay-pane').length == 1) {
                    this.buttonClickService.clickOnButton(event, 'save')
                }
            },
            'ctrl.σ': (event: KeyboardEvent) => {
                event.preventDefault()
                if (document.getElementsByClassName('cdk-overlay-pane').length == 1) {
                    this.buttonClickService.clickOnButton(event, 'save')
                }
            },
            'ctrl.d': (event: KeyboardEvent) => {
                event.preventDefault()
                if (document.getElementsByClassName('cdk-overlay-pane').length == 1) {
                    this.buttonClickService.clickOnButton(event, 'delete')
                }
            },
            'ctrl.δ': (event: KeyboardEvent) => {
                event.preventDefault()
                if (document.getElementsByClassName('cdk-overlay-pane').length == 1) {
                    this.buttonClickService.clickOnButton(event, 'delete')
                }
            }
        }, {
            priority: 2,
            inputs: true
        })
    }

    private addTabIndexToInput(): void {
        this.helperService.addTabIndexToInput(this.elementRef, this.renderer)
    }

    private closeForm(id: number, isDeleted: boolean) {
        if (isDeleted) {
            this.dialogRef.close(this.form.value.id)
        } else {
            this.form.patchValue({ 'id': id })
            this.dialogRef.close(this.form.value)
        }
    }

    private deleteFromBrowserStorage() {
        this.dexieService.remove('boats', this.form.value.id)
    }

    private flattenForm(): BoatWriteDto {
        return {
            id: this.form.value.id,
            description: this.form.value.description,
            boatUsageId: this.form.controls['boatUsage'].value['id'],
            hullTypeId: this.form.controls['hullType'].value['id'],
            nationalityId: this.form.controls['nationality'].value['id'],
            insurance: {
                id: this.form.value.insurance.id,
                boatId: this.form.value.insurance.boatId,
                company: this.form.value.insurance.company,
                contractNo: this.form.value.insurance.contractNo,
                expireDate: this.form.value.insurance.expireDate ? this.dateHelperService.formatDateToIso(new Date(this.form.value.insurance.expireDate)) : null
            },
            fishingLicence: {
                id: this.form.value.fishingLicence.id,
                boatId: this.form.value.fishingLicence.boatId,
                issuingAuthority: this.form.value.fishingLicence.issuingAuthority,
                licenceNo: this.form.value.fishingLicence.licenceNo,
                expireDate: this.form.value.fishingLicence.expireDate ? this.dateHelperService.formatDateToIso(new Date(this.form.value.fishingLicence.expireDate)) : null
            },
            loa: this.form.value.loa,
            beam: this.form.value.beam,
            draft: this.form.value.draft,
            registryPort: this.form.value.registryPort,
            registryNo: this.form.value.registryNo,
            isAthenian: this.form.value.isAthenian,
            isFishingBoat: this.form.value.isFishingBoat,
            isActive: this.form.value.isActive,
            putAt: this.form.value.putAt
        }
    }

    private focusOnField(): void {
        this.helperService.focusOnField()
    }

    private filterAutocomplete(array: string, field: string, value: any): any[] {
        if (typeof value !== 'object') {
            const filtervalue = value.toLowerCase()
            return this[array].filter((element: { [x: string]: string; }) =>
                element[field].toLowerCase().startsWith(filtervalue))
        }
    }

    private populateDropdowns(): void {
        this.populateDropdownFromDexieDB('hullTypes', 'dropdownHullTypes', 'hullType', 'description', 'description')
        this.populateDropdownFromDexieDB('boatUsages', 'dropdownBoatUsages', 'boatUsage', 'description', 'description')
        this.populateDropdownFromDexieDB('nationalities', 'dropdownNationalities', 'nationality', 'description', 'description')
    }

    private populateDropdownFromDexieDB(dexieTable: string, filteredTable: string, formField: string, modelProperty: string, orderBy: string): void {
        this.dexieService.table(dexieTable).orderBy(orderBy).toArray().then((response) => {
            this[dexieTable] = response.filter(x => x.isActive)
            this[filteredTable] = this.form.get(formField).valueChanges.pipe(startWith(''), map(value => this.filterAutocomplete(dexieTable, modelProperty, value)))
        })
    }

    private populateFieldsFromApi(): void {
        this.boatHttpService.getSingle(this.data).subscribe(response => {
            this.form.setValue({
                id: response.body.id,
                description: response.body.description,
                boatUsage: response.body.boatUsage,
                hullType: response.body.hullType,
                nationality: response.body.nationality,
                loa: response.body.loa,
                beam: response.body.beam,
                draft: response.body.draft,
                registryPort: response.body.registryPort,
                registryNo: response.body.registryNo,
                insurance: {
                    id: response.body.insurance.id,
                    boatId: response.body.insurance.boatId,
                    company: response.body.insurance.company,
                    contractNo: response.body.insurance.contractNo,
                    expireDate: response.body.insurance.expireDate ? this.dateHelperService.formatDateToIso(new Date(response.body.insurance.expireDate)) : null,
                },
                fishingLicence: {
                    id: response.body.fishingLicence.id,
                    boatId: response.body.fishingLicence.boatId,
                    issuingAuthority: response.body.fishingLicence.issuingAuthority,
                    licenceNo: response.body.fishingLicence.licenceNo,
                    expireDate: response.body.fishingLicence.expireDate ? this.dateHelperService.formatDateToIso(new Date(response.body.fishingLicence.expireDate)) : null,
                },
                isAthenian: response.body.isAthenian,
                isFishingBoat: response.body.isFishingBoat,
                isActive: response.body.isActive,
                postAt: response.body.postAt,
                postUser: response.body.postUser,
                putAt: response.body.putAt,
                putUser: response.body.putUser
            })
        })
    }

    private saveRecordToApi(x: BoatWriteDto): Promise<any> {
        return new Promise((resolve) => {
            this.boatHttpService.save(x).subscribe({
                next: (response) => {
                    if (response.code == 200) {
                        this.closeForm(response.body.id, false)
                        resolve(response)
                    }
                },
                error: (errorFromInterceptor) => {
                    this.showErrorFromApi(errorFromInterceptor)
                }
            })
        })
    }

    private setApiBusyStatus(status: boolean): void {
        this.isApiBusy = status
    }

    private setLocale(): void {
        this.dateAdapter.setLocale(this.localStorageService.getLanguage())
    }

    private showErrorFromApi(errorFromInterceptor: any) {
        this.dialogService.open(this.messageDialogService.filterResponse(errorFromInterceptor), 'error', ['ok'])
    }

    private updateBrowserRecordFromApi(response: any): void {
        this.dexieService.update('boats', response)
    }

    //#endregion

    //#region getters

    get description(): AbstractControl {
        return this.form.get('description')
    }

    get boatUsage(): AbstractControl {
        return this.form.get('boatUsage')
    }

    get hullType(): AbstractControl {
        return this.form.get('hullType')
    }

    get nationality(): AbstractControl {
        return this.form.get('nationality')
    }

    get loa(): AbstractControl {
        return this.form.get('loa')
    }

    get beam(): AbstractControl {
        return this.form.get('beam')
    }

    get draft(): AbstractControl {
        return this.form.get('draft')
    }

    get registryPort(): AbstractControl {
        return this.form.get('registryPort')
    }

    get registryNo(): AbstractControl {
        return this.form.get('registryNo')
    }

    get insuranceCompany(): AbstractControl {
        return this.form.get('insurance.company')
    }

    get contractNo(): AbstractControl {
        return this.form.get('insurance.contractNo')
    }

    get insuranceExpireDate(): AbstractControl {
        return this.form.get('insurance.expireDate')
    }

    get issuingAuthority(): AbstractControl {
        return this.form.get('fishingLicence.issuingAuthority')
    }

    get licenceNo(): AbstractControl {
        return this.form.get('fishingLicence.licenceNo')
    }

    get fishingLicenceExpireDate(): AbstractControl {
        return this.form.get('fishingLicence.expireDate')
    }

    //#endregion

}