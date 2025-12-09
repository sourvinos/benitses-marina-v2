import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { Observable } from 'rxjs'
// Custom
import { BoatAutoCompleteVM } from '../view-models/boat-autocomplete-vm'
import { HttpDataService } from 'src/app/shared/services/http-data.service'
import { environment } from 'src/environments/environment'

@Injectable({ providedIn: 'root' })

export class BoatHttpService extends HttpDataService {

    constructor(httpClient: HttpClient) {
        super(httpClient, environment.apiUrl + '/boats')
    }

    public getForBrowser(): Observable<BoatAutoCompleteVM[]> {
        return this.http.get<BoatAutoCompleteVM[]>(environment.apiUrl + '/boats/getForBrowser')
    }

    public saveRecord(formData: any): Observable<any> {
        return formData.boatId == null
            ? this.http.post<any>(this.url, formData)
            : this.http.put<any>(this.url, formData)
    }

}
