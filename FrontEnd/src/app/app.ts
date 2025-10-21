import { Component, signal, VERSION } from '@angular/core'
import { RouterOutlet } from '@angular/router'

@Component({
    selector: 'app-root',
    imports: [RouterOutlet],
    templateUrl: './app.html',
    styleUrl: './app.css'
})

export class App {

    protected readonly title = signal('FrontEnd')

    public getNgVersion(): string {
        return VERSION.full
    }

}
