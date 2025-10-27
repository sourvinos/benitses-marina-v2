import { ChangeDetectorRef, Component } from '@angular/core'
import { NavigationCancel, NavigationEnd, NavigationError, NavigationStart, Router, RouterOutlet } from '@angular/router'
// Custom
import { routeAnimation } from '../shared/animations/animations'
import { LoadingSpinnerService } from '../shared/services/loading-spinner.service'
import { CryptoService } from '../shared/services/crypto.service'
import { SessionStorageService } from '../shared/services/session-storage.service'

@Component({
    selector: 'root',
    templateUrl: './app.html',
    styleUrls: ['./app.css'],
    animations: [routeAnimation],
    imports: [RouterOutlet]
})

export class App {

    //#region variables

    public isLoading = true

    //#endregion

    constructor(private changeDetector: ChangeDetectorRef, private cryptoService: CryptoService, private loadingSpinnerService: LoadingSpinnerService, private router: Router, private sessionStorageService: SessionStorageService) {
        this.router.events.subscribe((routerEvent) => {
            if (routerEvent instanceof NavigationStart) {
                this.isLoading = true
            }
            if (routerEvent instanceof NavigationEnd || routerEvent instanceof NavigationCancel || routerEvent instanceof NavigationError) {
                this.isLoading = false
            }
        })
    }

    //#endregion

    //#region lifecycle hooks

    ngOnInit(): void {
        this.initLoadingSpinner()
        this.openBroadcastChannel()
        this.isUserConnected()
    }

    //#endregion

    //#region private methods

    private initLoadingSpinner(): void {
        this.loadingSpinnerService.getSpinnerObserver().subscribe((status) => {
            this.isLoading = status == 'start'
            this.changeDetector.detectChanges()
        })
    }

    private isUserConnected(): void {
        if (this.cryptoService.decrypt(this.sessionStorageService.getItem('userId')) != '' && window.location.href.includes('resetPassword') == false) {
            // this.accountService.logout()
        }
    }

    private openBroadcastChannel(): void {
        new BroadcastChannel('test').postMessage('open')
    }

    //#endregion

}
