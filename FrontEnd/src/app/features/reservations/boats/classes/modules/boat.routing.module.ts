import { NgModule } from '@angular/core'
import { Routes, RouterModule } from '@angular/router'
// Custom
import { AuthGuardService } from 'src/app/shared/services/auth-guard.service'
import { BoatListResolver } from '../resolvers/boat-list.resolver'
import { BoatListComponent } from '../../user-interface/boat-list.component'

const routes: Routes = [
    { path: '', component: BoatListComponent, canActivate: [AuthGuardService], resolve: { boatList: BoatListResolver } },
    // { path: 'new', component: BoatFormComponent, canActivate: [AuthGuardService] },
    // { path: ':id', component: BoatFormComponent, canActivate: [AuthGuardService], resolve: { boatForm: BoatFormResolver } }
]

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class BoatRoutingModule { }