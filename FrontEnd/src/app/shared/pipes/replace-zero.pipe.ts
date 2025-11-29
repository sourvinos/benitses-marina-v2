import { Pipe, PipeTransform } from '@angular/core'

@Pipe({ name: 'replaceZero', standalone: false })

export class ReplaceZeroPipe implements PipeTransform {

    transform(value: number): number | string {
        return value == 0
            ? ''
            : value
    }

}