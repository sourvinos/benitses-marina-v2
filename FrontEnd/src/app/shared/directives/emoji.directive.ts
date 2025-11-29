import { Directive, Input, TemplateRef, ViewContainerRef } from '@angular/core'

@Directive({ selector: '[isFormInvalid]', standalone: false })

export class EmojiDirective {

    @Input() isFormInvalid: boolean

    constructor(private templateRef: TemplateRef<any>, private viewContainerRef: ViewContainerRef) { }

    ngOnChanges(): void {
        if (this.isFormInvalid) {
            this.viewContainerRef.createEmbeddedView(this.templateRef)
        } else {
            this.viewContainerRef.clear()
        }
    }

}
