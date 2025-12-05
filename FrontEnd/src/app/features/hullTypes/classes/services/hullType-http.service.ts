import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { Observable } from 'rxjs'
// Custom
import { HullTypeAutoCompleteVM } from '../view-models/hullType-autocomplete-vm'
import { HttpDataService } from 'src/app/shared/services/http-data.service'
import { environment } from 'src/environments/environment'

@Injectable({ providedIn: 'root' })

export class HullTypeHttpService extends HttpDataService {

    constructor(httpClient: HttpClient) {
        super(httpClient, environment.apiUrl + '/hullTypes')
    }

    public getForBrowser(): Observable<HullTypeAutoCompleteVM[]> {
        return this.http.get<HullTypeAutoCompleteVM[]>(environment.apiUrl + '/hullTypes/getForBrowser')
    }

}
