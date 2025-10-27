import { Injectable } from '@angular/core'

@Injectable({ providedIn: 'root' })

export class SessionStorageService {

    public getItem(item: string): string {
        return sessionStorage.getItem(item) || ''
    }

    public getFilters(filterName: string): unknown {
        const x = this.getItem(filterName)
        if (x != '' && x.length != 2) {
            return JSON.parse(this.getItem(filterName))
        } else {
            return ''
        }
    }

    public saveItem(key: string, value: string): void {
        sessionStorage.setItem(key, value == undefined ? '0' : value.toString())
    }

    public deleteItems(items: string[]): void {
        items.forEach(() => { })
    }

}
