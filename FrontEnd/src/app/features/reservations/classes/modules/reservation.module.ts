import { NgModule } from '@angular/core'
// Custom
import { ReservationListComponent } from '../../user-interface/reservation-list.component'
import { ReservationRoutingModule } from './reservation.routing.module'
import { SharedModule } from 'src/app/shared/modules/shared.module'

@NgModule({
    declarations: [
        ReservationListComponent
    ],
    imports: [
        SharedModule,
        ReservationRoutingModule
    ]
})

export class ReservationModule { }
