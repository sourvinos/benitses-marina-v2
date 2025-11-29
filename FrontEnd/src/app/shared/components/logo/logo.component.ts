import { Component } from '@angular/core'
// Custom
import { LocalStorageService } from '../../services/local-storage.service'

@Component({
    selector: 'logo',
    standalone: false,
    styleUrls: ['./logo.component.css'],
    templateUrl: './logo.component.html'
})

export class LogoComponent {

    constructor(private localStorageService: LocalStorageService) { }

    public getLogo(): string {
        return '../../../../assets/images/logos/' + 'logo-' + this.localStorageService.getItem('theme') + '.svg'
    }

}
