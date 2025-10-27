import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs'

export class HttpDataService {

    constructor(public http: HttpClient, public url: string) { }

    public getAll(): Observable<unknown[]> {
        return this.http.get<unknown[]>(this.url)
    }

}
