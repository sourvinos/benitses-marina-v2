import { Pipe } from '@angular/core'
import { DomSanitizer, SafeStyle } from '@angular/platform-browser'

@Pipe({ name: 'safeStyle', standalone: false })

export class SafeStylePipe {

    constructor(private sanitizer: DomSanitizer) { }

    public transform(value: string): SafeStyle {
        return this.sanitizer.bypassSecurityTrustStyle(value)
    }

}
