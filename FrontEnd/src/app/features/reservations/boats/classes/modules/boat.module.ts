import { NgModule } from '@angular/core'
// Custom
import { BoatListComponent } from '../../user-interface/boat-list.component'
import { BoatRoutingModule } from './boat.routing.module'
import { SharedModule } from '../../../../../shared/modules/shared.module'

@NgModule({
    declarations: [
        BoatListComponent,
    ],
    imports: [
        SharedModule,
        BoatRoutingModule
    ]
})

export class BoatModule { }
