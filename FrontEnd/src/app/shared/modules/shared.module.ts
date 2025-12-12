import { CommonModule } from '@angular/common'
import { FormsModule, ReactiveFormsModule } from '@angular/forms'
import { NgModule } from '@angular/core'
import { RouterModule } from '@angular/router'
// Custom
import { CatPageComponent } from '../components/cat-page/cat-page.component'
import { EmptyPageComponent } from '../components/empty-page/empty-page.component'
import { HomeButtonAndTitleComponent } from '../components/home-button-and-title/home-button-and-title.component'
import { InputTabStopDirective } from 'src/app/shared/directives/input-tabstop.directive'
import { LoadingSpinnerComponent } from '../components/loading-spinner/loading-spinner.component'
import { LogoComponent } from '../components/logo/logo.component'
import { MainFooterComponent } from '../components/home/main-footer.component'
import { MaterialModule } from './material.module'
import { MetadataPanelComponent } from '../components/metadata-panel/metadata-panel.component'
import { ModalDialogComponent } from '../components/modal-dialog/modal-dialog.component'
import { PrimeNgModule } from './primeng.module'
import { SafeStylePipe } from '../pipes/safe-style.pipe'
import { TableTotalFilteredRecordsComponent } from '../components/table-total-filtered-records/table-total-filtered-records.component'
import { ThemeSelectorComponent } from '../components/theme-selector/theme-selector.component'
import { SnackbarComponent } from '../components/snackbar/snackbar.component'

@NgModule({
    declarations: [
        CatPageComponent,
        EmptyPageComponent,
        HomeButtonAndTitleComponent,
        InputTabStopDirective,
        LoadingSpinnerComponent,
        LogoComponent,
        MainFooterComponent,
        MetadataPanelComponent,
        ModalDialogComponent,
        SafeStylePipe,
        SnackbarComponent,
        TableTotalFilteredRecordsComponent,
        ThemeSelectorComponent
    ],
    imports: [
        CommonModule,
        FormsModule,
        MaterialModule,
        PrimeNgModule,
        ReactiveFormsModule,
        RouterModule
    ],
    exports: [
        CatPageComponent,
        CommonModule,
        EmptyPageComponent,
        FormsModule,
        HomeButtonAndTitleComponent,
        InputTabStopDirective,
        LoadingSpinnerComponent,
        LogoComponent,
        MainFooterComponent,
        MaterialModule,
        MetadataPanelComponent,
        PrimeNgModule,
        ReactiveFormsModule,
        RouterModule,
        SnackbarComponent,
        TableTotalFilteredRecordsComponent,
        ThemeSelectorComponent
    ]
})

export class SharedModule { }
