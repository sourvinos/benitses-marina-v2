import { Component } from '@angular/core'
// Custom
import { environment } from 'src/environments/environment'

@Component({
    selector: 'empty-page',
    standalone: false,
    styleUrls: ['./empty-page.component.css'],
    templateUrl: './empty-page.component.html'
})

export class EmptyPageComponent {

    //#region variables

    public imgIsLoaded = false

    //#endregion

    //#region public methods

    public getIcon(filename: string): string {
        return environment.featuresIconDirectory + filename + '.svg'
    }

    public imageIsLoading(): any {
        return this.imgIsLoaded ? '' : 'skeleton'
    }

    public loadImage(): void {
        this.imgIsLoaded = true
    }

    //#endregion

}
