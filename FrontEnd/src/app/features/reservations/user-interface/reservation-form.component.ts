import { ActivatedRoute, Router } from '@angular/router'
import { Component, ElementRef, Renderer2 } from '@angular/core'
import { DateAdapter } from '@angular/material/core'
import { FormBuilder, FormGroup, AbstractControl, FormArray, Validators } from '@angular/forms'
import { MatAutocompleteTrigger } from '@angular/material/autocomplete'
import { map, Observable, startWith } from 'rxjs'
// Custom
import { CryptoService } from 'src/app/shared/services/crypto.service'
import { DateHelperService } from 'src/app/shared/services/date-helper.service'
import { DexieService } from 'src/app/shared/services/dexie.service'
import { DialogService } from 'src/app/shared/services/modal-dialog.service'
import { EmojiService } from 'src/app/shared/services/emoji.service'
import { FormResolved } from 'src/app/shared/classes/form-resolved'
import { HelperService } from 'src/app/shared/services/helper.service'
import { InputTabStopDirective } from 'src/app/shared/directives/input-tabstop.directive'
import { LocalStorageService } from 'src/app/shared/services/local-storage.service'
import { MessageDialogService } from 'src/app/shared/services/message-dialog.service'
import { MessageInputHintService } from 'src/app/shared/services/message-input-hint.service'
import { MessageLabelService } from 'src/app/shared/services/message-label.service'
import { ReservationBerthWriteDto } from '../classes/dtos/write/reservation-berth-write-dto'
import { ReservationHttpService } from '../classes/services/reservation-http.service'
import { ReservationReadDto } from '../classes/dtos/read/reservation-read-dto'
import { ReservationWriteDto } from '../classes/dtos/write/reservation-write-dto'
import { SessionStorageService } from 'src/app/shared/services/session-storage.service'
import { SimpleEntity } from 'src/app/shared/classes/simple-entity'
import { environment } from 'src/environments/environment'
import { BoatBrowserListVM } from '../../boats/classes/view-models/boat-browser-list-vm'
import { ValidationService } from 'src/app/shared/services/validation.service'

// https://stackblitz.com/edit/angular-formarray-validation-error?file=app%2Fautocomplete-simple-example.html

@Component({
    selector: 'reservation-form',
    templateUrl: './reservation-form.component.html',
    styleUrls: ['../../../../assets/styles/custom/forms.css', './reservation-form.component.css']
})

export class ReservationFormComponent {

    //#region common

    private reservation: ReservationReadDto
    private reservationId: string
    public feature = 'reservationForm'
    public featureIcon = 'reservations'
    public form: FormGroup
    public icon = 'arrow_back'
    public input: InputTabStopDirective
    public parentUrl = '/reservations'
    public imgIsLoaded = false

    //#endregion

    //#region autocompletes

    public dropdownBoats: Observable<SimpleEntity[]>
    public dropdownBerths: Observable<SimpleEntity[]>
    public dropdownBoatTypes: Observable<SimpleEntity[]>
    public dropdownBoatUsages: Observable<SimpleEntity[]>
    public dropdownPaymentStatuses: Observable<SimpleEntity[]>
    public isAutoCompleteDisabled = true

    //#endregion

    //#region berths

    public berthsArray: string[] = []

    //#endregion

    //#endregion

    constructor(
        private elementRef: ElementRef,
        private activatedRoute: ActivatedRoute,
        private renderer: Renderer2,
        private cryptoService: CryptoService,
        private dateAdapter: DateAdapter<any>,
        private dateHelperService: DateHelperService,
        private dexieService: DexieService,
        private dialogService: DialogService,
        private emojiService: EmojiService,
        private formBuilder: FormBuilder,
        private helperService: HelperService,
        private localStorageService: LocalStorageService,
        private messageDialogService: MessageDialogService,
        private messageHintService: MessageInputHintService,
        private messageLabelService: MessageLabelService,
        private reservationHttpService: ReservationHttpService,
        private router: Router,
        private sessionStorageService: SessionStorageService
    ) { }

    //#region lifecycle hooks

    ngOnInit(): void {
        this.initForm()
        this.setRecordId()
        this.getRecord()
        this.populateFields()
        this.populateBerths()
        this.populateDropdowns()
        this.setLocale()
    }

    ngAfterViewInit(): void {
        this.addTabIndexToInput()
        this.focusOnField()
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

    public getEmoji(emoji: string): string {
        return this.emojiService.getEmoji(emoji)
    }

    public getHint(id: string, minmax = 0): string {
        return this.messageHintService.getDescription(id, minmax)
    }

    public getIcon(filename: string): string {
        return environment.featuresIconDirectory + filename + '.svg'
    }

    public getLabel(id: string): string {
        return this.messageLabelService.getDescription(this.feature, id)
    }

    public getNewOrEditHeader(): string {
        return this.form.value.reservationId == '' ? 'headerNew' : 'headerEdit'
    }

    public getRemarksLength(): any {
        return this.form.value.remarks != null ? this.form.value.remarks.length : 0
    }

    public getFinancialRemarksLength(): any {
        return this.form.value.financialRemarks != null ? this.form.value.financialRemarks.length : 0
    }

    public imageIsLoading(): any {
        return this.imgIsLoaded ? '' : 'skeleton'
    }

    public isAdmin(): boolean {
        return this.cryptoService.decrypt(this.sessionStorageService.getItem('isAdmin')) == 'true' ? true : false
    }

    public isFishingBoat(): boolean {
        return this.form.value.isFishingBoat
    }

    public isNotNewRecord(): boolean {
        return this.form.value.reservationId == ''
    }

    public isNewRecord(): boolean {
        return this.form.value.reservationId != '' && this.form.pristine == true
    }

    public isNotNewRecordAndIsReservationNotInStorage(): boolean {
        return this.form.value.reservationId == '' && this.localStorageService.getItem('reservation').length != 0
    }

    public loadImage(): void {
        this.imgIsLoaded = true
    }

    public onAddBerthTextBox(): void {
        const control = <FormArray>this.form.get('berths')
        const newGroup = this.formBuilder.group({
            reservationId: this.form.value.reservationId,
            id: 0,
            description: ['', [Validators.required]]
        })
        control.push(newGroup)
        this.berthsArray.push(this.form.controls.berths.value)
        this.addTabIndexToInput()
    }

    public onDelete(): void {
        this.dialogService.open(this.messageDialogService.confirmDelete(), 'question', ['abort', 'ok']).subscribe(response => {
            if (response) {
                this.reservationHttpService.delete(this.form.value.reservationId).subscribe({
                    complete: () => {
                        this.helperService.doPostSaveFormTasks(this.messageDialogService.success(), 'ok', this.parentUrl, true)
                    },
                    error: (errorFromInterceptor) => {
                        this.dialogService.open(this.messageDialogService.filterResponse(errorFromInterceptor), 'error', ['ok'])
                    }
                })
            }
        })
    }

    public onRemoveBerth(berthIndex: number): void {
        const berths = <FormArray>this.form.get('berths')
        berths.removeAt(berthIndex)
        this.berthsArray.splice(berthIndex, 1)
    }

    public onSave(closeForm: boolean): void {
        this.saveRecord(this.flattenForm(), closeForm)
    }

    public openOrCloseAutoComplete(trigger: MatAutocompleteTrigger, element: any): void {
        this.helperService.openOrCloseAutocomplete(this.form, element, trigger)
    }

    public trimFilename(filename: string): string {
        return filename.substring(36, filename.length - 4)
    }

    //#endregion

    //#region private methods

    private populateDropdowns(): void {
        this.populateDropdownFromDexieDB('boats', 'dropdownBoats', 'boat', 'description', 'description')
    }

    private populateDropdownFromDexieDB(dexieTable: string, filteredTable: string, formField: string, modelProperty: string, orderBy: string): void {
        this.dexieService.table(dexieTable).orderBy(orderBy).toArray().then((response) => {
            this[dexieTable] = this.reservationId == undefined ? response.filter(x => x.isActive) : response
            this[filteredTable] = this.form.get(formField).valueChanges.pipe(startWith(''), map(value => this.filterAutocomplete(dexieTable, modelProperty, value)))
        })
    }


    private addTabIndexToInput(): void {
        this.helperService.addTabIndexToInput(this.elementRef, this.renderer)
    }

    public onValidateBerth(event: any, index: number): void {
        this.dexieService.getByDescription('berths', event.target.value).then((response) => {
            if (response) {
                this.form.value.berths[index] = {
                    reservationId: this.form.value.reservationId,
                    id: response ? response.id : null,
                    description: response ? response.description : null,
                }
            } else {
                let controlArray = <FormArray>this.form.controls["berths"];
                controlArray.controls[index].patchValue({
                    reservationId: this.form.value.reservationId,
                    id: 0,
                    description: ''
                });
            }
        })
    }

    private attemptToSaveRecord(event: KeyboardEvent, closeForm: boolean): void {
        this.form.valid ? ((): void => { this.onSave(closeForm); event.preventDefault() })() : ((): void => { event.preventDefault() })()
    }

    private filterAutocomplete(array: string, field: string, value: any): any[] {
        if (typeof value !== 'object') {
            const filtervalue = value.toLowerCase()
            return this[array].filter((element: { [x: string]: string; }) =>
                element[field].toLowerCase().startsWith(filtervalue))
        }
    }

    private flattenBerths(): ReservationBerthWriteDto[] {
        const x: ReservationBerthWriteDto[] = []
        this.form.value.berths.forEach(berth => {
            const z = {
                reservationId: this.form.value.reservationId != '' ? this.form.value.reservationId : null,
                berthId: berth.id
            }
            x.push(z)
        });
        return x
    }

    private flattenForm(): ReservationWriteDto {
        const x = {
            reservationId: this.form.value.reservationId != '' ? this.form.value.reservationId : null,
            boatId: this.form.value.boat.id,
            fromDate: this.dateHelperService.formatDateToIso(new Date(this.form.value.fromDate)),
            toDate: this.dateHelperService.formatDateToIso(new Date(this.form.value.toDate)),
            days: this.form.value.days,
            berths: this.flattenBerths(),
            isPassingBy: this.form.value.isPassingBy,
            isDocked: this.form.value.isDocked,
            isDryDock: this.form.value.isDryDock,
            putAt: this.form.value.putAt
        }
        return x
    }

    private focusOnField(): void {
        this.helperService.focusOnField()
    }

    private getRecord(): Promise<any> {
        if (this.reservationId != undefined) {
            return new Promise((resolve) => {
                const formResolved: FormResolved = this.activatedRoute.snapshot.data['reservationForm']
                if (formResolved.error == null) {
                    this.reservation = formResolved.record.body
                    resolve(this.reservation)
                } else {
                    this.dialogService.open(this.messageDialogService.filterResponse(formResolved.error), 'error', ['ok']).subscribe(() => {
                        this.resetForm()
                        this.goBack()
                    })
                }
            })
        }
    }

    private goBack(): void {
        this.router.navigate([this.parentUrl])
    }

    private initForm(): void {
        this.form = this.formBuilder.group({
            reservationId: '',
            boat: this.formBuilder.group({
                foo: ['', [Validators.required, ValidationService.requireAutocomplete]],
            }),
            berths: this.formBuilder.array([]),
            fromDate: '',
            toDate: '',
            days: 0,
            isPassingBy: false,
            isDocked: false,
            isDryDock: false,
            postAt: '',
            postUser: '',
            putAt: '',
            putUser: ''
        })
    }

    private populateFields(): void {
        if (this.reservation != undefined) {
            this.form.setValue({
                reservationId: this.reservation.reservationId,
                boatDescription: this.reservation.boat.description,
                boat: {
                    id: this.reservation.boat.id,
                    hullType: {
                        id: this.reservation.boat.hullType.id,
                        description: this.reservation.boat.hullType.description
                    },
                    usage: {
                        id: this.reservation.boat.usage.id,
                        description: this.reservation.boat.usage.description
                    },
                    nationality: {
                        id: this.reservation.boat.nationality.id,
                        description: this.reservation.boat.nationality.description,
                        code: this.reservation.boat.nationality.code
                    },
                    insurance: {
                        id: this.reservation.boat.insurance.id,
                        boatId: this.reservation.boat.insurance.boatId,
                        company: this.reservation.boat.insurance.company,
                        contractNo: this.reservation.boat.insurance.contractNo,
                        expireDate: this.reservation.boat.insurance.expireDate,
                        isExpired: this.reservation.boat.insurance.isExpired
                    },
                    loa: this.reservation.boat.loa,
                    beam: this.reservation.boat.beam,
                    draft: this.reservation.boat.draft,
                    registryPort: this.reservation.boat.registryPort,
                    registryNo: this.reservation.boat.registryNo
                },
                fromDate: this.reservation.fromDate,
                toDate: this.reservation.toDate,
                days: this.reservation.days,
                berths: [],
                isPassingBy: this.reservation.isPassingBy,
                isDocked: this.reservation.isDocked,
                isDryDock: this.reservation.isDryDock,
                postAt: this.reservation.postAt,
                postUser: this.reservation.postUser,
                putAt: this.reservation.putAt,
                putUser: this.reservation.putUser
            })
        }
    }

    private populateBerths(): void {
        if (this.reservation && this.reservation.berths.length >= 1) {
            this.reservation.berths.forEach(berth => {
                const control = <FormArray>this.form.get('berths')
                const newGroup = this.formBuilder.group({
                    reservationId: berth.reservationId,
                    id: berth.berth.id,
                    description: [berth.berth.description, Validators.required]
                })
                control.push(newGroup)
                this.berthsArray.push(this.form.controls.berths.value)
            })
        } else {
            this.onAddBerthTextBox()
        }
    }

    private resetForm(): void {
        this.form.reset()
    }

    private saveRecord(reservation: ReservationWriteDto, closeForm: boolean): void {
        this.reservationHttpService.saveReservation(reservation).subscribe({
            next: (response) => {
                this.helperService.doPostSaveFormTasks(
                    response.code == 200 ? this.messageDialogService.success() : '',
                    response.code == 200 ? 'ok' : 'ok',
                    this.parentUrl,
                    closeForm)
                this.localStorageService.deleteItem('reservation')
                this.form.patchValue(
                    {
                        reservationId: response.body.reservationId,
                        postAt: response.body.postAt,
                        putAt: response.body.putAt
                    })
                this.form.markAsPristine()
                this.focusOnField()
            },
            error: (errorFromInterceptor) => {
                this.dialogService.open(this.messageDialogService.filterResponse(errorFromInterceptor), 'error', ['ok'])
            }
        })
    }

    private setLocale(): void {
        this.dateAdapter.setLocale(this.localStorageService.getLanguage())
    }

    private setRecordId(): void {
        this.activatedRoute.params.subscribe(x => {
            this.reservationId = x.id
        })
    }

    //#endregion

    //#region getters

    get foos(): AbstractControl {
        return this.form.get('boat.foo')
    }

    get fromDate(): AbstractControl {
        return this.form.get('fromDate')
    }

    get toDate(): AbstractControl {
        return this.form.get('toDate')
    }

    get days(): AbstractControl {
        return this.form.get('days')
    }

    //#endregion
    // public onPopulateBoatFields(event: any): void {
    //     this.dexieService.getByDescription('boats', event.target.value).then((response: BoatBrowserListVM) => {
    //         if (response) {
    //             this.form.value.boat = {
    //                 id: response.id,
    //                 description: response.description,
    //             }
    //         }
    //     })
    // }

}
