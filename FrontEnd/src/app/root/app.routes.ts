import { Routes } from '@angular/router'
import { LoginFormComponent } from '../features/login/user-interface/login-form.component'

export const routes: Routes = [
    { path: '', component: LoginFormComponent, pathMatch: 'full' },
]
