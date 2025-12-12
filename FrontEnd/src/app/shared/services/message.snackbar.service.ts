import { Injectable } from '@angular/core'
import { HttpClient } from '@angular/common/http'

@Injectable({ providedIn: 'root' })

export class MessageSnackbarService {

    //#region variables

    private messages: any = []
    private feature = 'snackbarMessages'

    //#endregion

    constructor(private httpClient: HttpClient) {
        this.getMessages()
    }

    //#region public methods

    public getDescription(feature: string, id: string): string {
        let description = ''
        this.messages.filter((f: { feature: string; labels: any[] }) => {
            if (f.feature === feature) {
                f.labels.filter(l => {
                    if (l.id == id) {
                        description = l.message
                    }
                })
            }
        })
        return description
    }

    public getMessages(): Promise<any> {
        const promise = new Promise((resolve) => {
            this.httpClient.get('assets/languages/snackbar.' + localStorage.getItem('language') + '.json').toPromise().then(
                response => {
                    this.messages = response
                    resolve(this.messages)
                })
        })
        return promise
    }

    public recordCreated(): string { return this.getDescription(this.feature, "recordCreated") }
    public recordDeleted(): string { return this.getDescription(this.feature, "recordDeleted") }
    public recordUpdated(): string { return this.getDescription(this.feature, "recordUpdated") }

    public filterError(errorCode: number, feature = 'snackbarMessages'): string {
        let returnValue = ''
        this.messages.filter((f: { feature: string; labels: any[] }) => {
            if (f.feature === feature) {
                if (typeof errorCode == 'number') {
                    f.labels.filter(l => { if (l.error == errorCode) { returnValue = l.message } })
                } else {
                    f.labels.filter(l => { if (l.error == 499) { returnValue = l.message } })
                }
            }
        })
        return returnValue
    }

}