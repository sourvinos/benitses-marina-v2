import { ActivatedRoute, Router } from '@angular/router'
import { Component, ElementRef, QueryList, ViewChild, ViewChildren } from '@angular/core'
import { MatDialog } from '@angular/material/dialog'
import { Table } from 'primeng/table'
// Custom
import { BoatFormDialogComponent } from './boat-form-dialog.component'
import { BoatListVM } from '../classes/view-models/boat-list-vm'
import { CryptoService } from 'src/app/shared/services/crypto.service'
import { DexieService } from 'src/app/shared/services/dexie.service'
import { DialogService } from 'src/app/shared/services/modal-dialog.service'
import { HelperService } from 'src/app/shared/services/helper.service'
import { ListResolved } from 'src/app/shared/classes/list-resolved'
import { MessageDialogService } from 'src/app/shared/services/message-dialog.service'
import { MessageLabelService } from 'src/app/shared/services/message-label.service'
import { MessageSnackbarService } from 'src/app/shared/services/message.snackbar.service'
import { SessionStorageService } from 'src/app/shared/services/session-storage.service'
import { SnackbarService } from 'src/app/shared/services/snackbar.service'

@Component({
    selector: 'boat-list',
    standalone: false,
    styleUrls: ['../../../../assets/styles/custom/lists.css', 'boat-list.component.css'],
    templateUrl: './boat-list.component.html'
})

export class BoatListComponent {

    //#region variables
    @ViewChild('table') table: Table

    private virtualElement: any
    public feature = 'boatList'
    public featureIcon = 'boat'
    public icon = 'boat'
    public parentUrl = '/home'
    public records: BoatListVM[] = []
    public recordsFilteredCount = 0
    public selectedRecords: BoatListVM[] = []

    //#endregion

    constructor(private activatedRoute: ActivatedRoute, private cryptoService: CryptoService, private dexieService: DexieService, private dialogService: DialogService, private helperService: HelperService, private messageDialogService: MessageDialogService, private messageLabelService: MessageLabelService, private messageSnackbarService: MessageSnackbarService, private router: Router, private sessionStorageService: SessionStorageService, private snackbarService: SnackbarService, public dialog: MatDialog) { }

    //#region lifecycle hooks

    ngOnInit(): void {
        this.loadRecords()
        setTimeout(() => {
            this.onResetTableFilters()
            this.dexieService.getLast('boats').then(response => {
                const x = document.getElementById(response.id);
                this.table.scrollTo({
                    top: x.getAttribute('data'),
                    left: 0,
                    behavior: 'smooth'
                })
                if (x != null) {
                    x.classList.add('p-highlight')
                }
            })
        }, 2000);
    }

    ngOnDestroy(): void {
        this.clearSessionStorage()
    }

    //#endregion

    //#region public methods

    public colorizeIcon(active: boolean): string {
        return active ? 'color-green' : 'color-red'
    }

    public getIcon(isActive: boolean, onlyTrue: boolean): string {
        return onlyTrue ? isActive ? 'check_circle' : '' : 'check_circle'
    }

    public getLabel(id: string): string {
        return this.messageLabelService.getDescription(this.feature, id)
    }

    public isAdmin(): boolean {
        return this.cryptoService.decrypt(this.sessionStorageService.getItem('isAdmin')) == 'true' ? true : false
    }

    public onEditRecord(id: string): void {
        this.storeScrollTop()
        this.storeSelectedId(id)
        this.navigateToRecord(id)
    }

    public onFilter(event: any, column: string, matchMode: string): void {
        if (event) this.table.filter(event, column, matchMode)
    }

    public onFilterRecords(event: any): void {
        this.recordsFilteredCount = event.filteredValue.length
    }

    public onHighlightRow(id: any): void {
        this.helperService.highlightRow(id)
    }

    public onNewRecord(): void {
        const dialogRef = this.dialog.open(BoatFormDialogComponent, {
            data: null,
            panelClass: 'dialog',
            height: '700px',
            width: '900px'
        })
        dialogRef.afterClosed().subscribe((response) => {
            if (response) {
                this.dexieService.getAll('boats').then((response) => {
                    this.populateList(response)
                    this.scrollToNewRow()
                    // this.hightlightSavedRow()
                    this.showSnackbar(this.messageSnackbarService.recordCreated(), 'snackbar-info')
                })
            }
        })

    }

    public onResetTableFilters(): void {
        this.helperService.clearTableTextFilters(this.table)
    }

    //#endregion

    //#region private methods

    private clearSessionStorage() {
        this.sessionStorageService.deleteItems([
            { 'item': 'boatList-filters', 'when': 'always' },
            { 'item': 'boatList-id', 'when': 'always' },
            { 'item': 'boatList-scrollTop', 'when': 'always' }
        ])
    }

    private doInitTableSort(): void {
        this.table.multiSortMeta = [{ field: 'description', order: 1 }]
    }

    private doVirtualTableTasks(): void {
        setTimeout(() => {
            this.getVirtualElement()
            this.doInitTableSort()
        }, 1000)
    }

    private getVirtualElement(): void {
        this.virtualElement = document.getElementsByClassName('p-scroller-inline')[0]
    }

    private goBack(): void {
        this.router.navigate([this.parentUrl])
    }

    private hightlightSavedRow(): void {
        this.helperService.highlightSavedRow(this.feature)
    }

    private loadRecords(): Promise<any> {
        return new Promise((resolve) => {
            const listResolved: ListResolved = this.activatedRoute.snapshot.data[this.feature]
            if (listResolved.error == null) {
                this.records = listResolved.list
                this.recordsFilteredCount = this.records.length
                resolve(this.records)
            } else {
                this.dialogService.open(this.messageDialogService.filterResponse(listResolved.error), 'error', ['ok']).subscribe(() => {
                    this.goBack()
                })
            }
        })
    }

    private navigateToRecord(id: any): void {
        const dialogRef = this.dialog.open(BoatFormDialogComponent, {
            data: id,
            panelClass: 'dialog',
            height: '587px',
            width: '900px'
        })
        dialogRef.afterClosed().subscribe((response) => {
            if (response) {
                this.dexieService.getAll('boats').then((response) => {
                    this.populateList(response)
                    this.scrollToSavedPosition()
                    this.hightlightSavedRow()
                    this.showSnackbar(this.messageSnackbarService.recordUpdated(), 'snackbar-info')
                })
            }
        })
    }

    private populateList(response: any) {
        this.records = response
    }

    private scrollToNewRow(): void {
        this.dexieService.getLast('boats').then(response => {
            console.log(response)
            let rows = document.getElementsByTagName('table')[0].rows;
            let elementToScrollTo = rows[100];
            elementToScrollTo?.scrollIntoView({ behavior: 'smooth' });
        })
        // this.helperService.scrollToSavedPosition(this.virtualElement, this.feature)
    }

    private scrollToSavedPosition(): void {
        this.helperService.scrollToSavedPosition(this.virtualElement, this.feature)
    }

    private showSnackbar(message: string, type: string): void {
        this.snackbarService.open(message, type)
    }

    private storeSelectedId(boatId: string): void {
        this.sessionStorageService.saveItem(this.feature + '-id', boatId)
    }

    private storeScrollTop(): void {
        this.sessionStorageService.saveItem(this.feature + '-scrollTop', this.virtualElement.scrollTop)
    }

    //#endregion

    public calculateRowIndex(rowIndex: number): number {
        return rowIndex += 32
    }

}
