import { HttpClient } from '@angular/common/http'
import { Injectable, NgZone } from '@angular/core'
import { Router } from '@angular/router'
// Custom
import { CryptoService } from './crypto.service'
import { SessionStorageService } from './session-storage.service'
import { environment } from '../../../environments/environment'
import { HttpDataService } from './http-data.service'

@Injectable({ providedIn: 'root' })

export class AccountService extends HttpDataService {

    //#region variables

    private apiUrl = environment.apiUrl
    private urlForgotPassword = this.apiUrl + '/account/patchUserWithResetEmailPending'
    private urlResetPassword = this.apiUrl + '/account/resetPassword'
    private urlToken = this.apiUrl + '/auth/auth'

    //#endregion

    constructor(httpClient: HttpClient, private cryptoService: CryptoService, private ngZone: NgZone, private router: Router, private sessionStorageService: SessionStorageService) {
        super(httpClient, environment.apiUrl)
    }

    //#region public methods

    public clearSessionStorage(): void {
        this.sessionStorageService.deleteItems([])
    }

    public logout(): void {
        this.navigateToLogin()
        this.clearSessionStorage()
    }

    private navigateToLogin(): void {
        this.ngZone.run(() => {
            this.router.navigate(['/'])
        })
    }

}
