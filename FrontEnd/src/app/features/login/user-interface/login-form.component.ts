import { Component } from '@angular/core'
import { FormBuilder, FormGroup } from '@angular/forms'
import { Router } from '@angular/router'
import { Subject } from 'rxjs'
import { Title } from '@angular/platform-browser'
// Custom

@Component({
    selector: 'login-form',
    templateUrl: './login-form.component.html',
    standalone: false,
    styleUrls: ['./login-form.component.css']
})

export class LoginFormComponent {

    //#region variables

    public feature = 'loginForm'
    public featureIcon = 'login'
    public form: FormGroup | undefined
    public icon = ''
    public parentUrl = null

    public hidePassword = true
    public isLoading = new Subject<boolean>()

    //#endregion

    constructor(private formBuilder: FormBuilder, private router: Router, private titleService: Title) { }


}
