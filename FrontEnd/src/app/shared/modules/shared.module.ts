import { CommonModule } from '@angular/common'
import { FormsModule, ReactiveFormsModule } from '@angular/forms'
import { NgModule } from '@angular/core'
import { NgxCurrencyDirective, NgxCurrencyInputMode, provideEnvironmentNgxCurrency } from 'ngx-currency'
import { RouterModule } from '@angular/router'
// Custom
import { AbsPipe } from '../pipes/abs.pipe'
import { CatPageComponent } from '../components/cat-page/cat-page.component'
import { DateRangePickerComponent } from '../components/date-range-picker/date-range-picker.component'
import { EmojiDirective } from '../directives/emoji.directive'
import { EmptyPageComponent } from '../components/empty-page/empty-page.component'
import { HomeButtonAndTitleComponent } from '../components/home-button-and-title/home-button-and-title.component'
import { InputTabStopDirective } from 'src/app/shared/directives/input-tabstop.directive'
import { LoadingSpinnerComponent } from '../components/loading-spinner/loading-spinner.component'
import { LogoComponent } from '../components/logo/logo.component'
import { MainFooterComponent } from '../components/home/main-footer.component'
import { MaterialModule } from './material.module'
import { MetadataPanelComponent } from '../components/metadata-panel/metadata-panel.component'
import { ModalDebugDialogComponent } from '../components/modal-debug-dialog/modal-debug-dialog.component'
import { ModalDialogComponent } from '../components/modal-dialog/modal-dialog.component'
import { PadNumberPipe } from '../pipes/pad-number.pipe'
import { PrettyPrintPipe } from '../pipes/json-pretty.pipe'
import { PrimeNgModule } from './primeng.module'
import { ReplaceZeroPipe } from '../pipes/replace-zero.pipe'
import { SafeStylePipe } from '../pipes/safe-style.pipe'
import { TableTotalFilteredRecordsComponent } from '../components/table-total-filtered-records/table-total-filtered-records.component'
import { ThemeSelectorComponent } from '../components/theme-selector/theme-selector.component'
import { TrimStringPipe } from './../pipes/string-trim.pipe'

@NgModule({
    declarations: [
        AbsPipe,
        CatPageComponent,
        DateRangePickerComponent,
        EmojiDirective,
        EmptyPageComponent,
        HomeButtonAndTitleComponent,
        InputTabStopDirective,
        LoadingSpinnerComponent,
        LogoComponent,
        MainFooterComponent,
        MetadataPanelComponent,
        ModalDebugDialogComponent,
        ModalDialogComponent,
        PadNumberPipe,
        PrettyPrintPipe,
        ReplaceZeroPipe,
        SafeStylePipe,
        TableTotalFilteredRecordsComponent,
        ThemeSelectorComponent,
        TrimStringPipe
    ],
    imports: [
        CommonModule,
        FormsModule,
        MaterialModule,
        NgxCurrencyDirective,
        PrimeNgModule,
        ReactiveFormsModule,
        RouterModule
    ],
    exports: [
        AbsPipe,
        CatPageComponent,
        CommonModule,
        DateRangePickerComponent,
        EmojiDirective,
        EmptyPageComponent,
        FormsModule,
        HomeButtonAndTitleComponent,
        InputTabStopDirective,
        LoadingSpinnerComponent,
        LogoComponent,
        MainFooterComponent,
        MaterialModule,
        MetadataPanelComponent,
        ModalDebugDialogComponent,
        NgxCurrencyDirective,
        PadNumberPipe,
        PrettyPrintPipe,
        PrimeNgModule,
        ReactiveFormsModule,
        ReplaceZeroPipe,
        RouterModule,
        TableTotalFilteredRecordsComponent,
        ThemeSelectorComponent,
        TrimStringPipe
    ], providers: [
        provideEnvironmentNgxCurrency({
            align: 'right',
            allowNegative: false,
            allowZero: true,
            decimal: '.',
            inputMode: NgxCurrencyInputMode.Natural,
            max: null,
            min: null,
            nullable: true,
            precision: 2,
            prefix: '',
            suffix: '',
            thousands: ','
        })
    ]
})

export class SharedModule { }
