import { NgModule } from '@angular/core'
// Custom
import { BoatListComponent } from '../../user-interface/boat-list.component'
import { BoatRoutingModule } from './boat.routing.module'
import { SharedModule } from '../../../../shared/modules/shared.module'
import { BoatFormDialogComponent } from '../../user-interface/boat-form-dialog.component'

@NgModule({
    declarations: [
        BoatListComponent,
        BoatFormDialogComponent
    ],
    imports: [
        SharedModule,
        BoatRoutingModule
    ]
})

export class BoatModule { }
