import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { Observable } from 'rxjs'
// Custom
import { HttpDataService } from 'src/app/shared/services/http-data.service'
import { environment } from 'src/environments/environment'
import { BerthAutoCompleteVM } from '../view-models/berth-autocomplete-vm'

@Injectable({ providedIn: 'root' })

export class BerthHttpService extends HttpDataService {

    constructor(httpClient: HttpClient) {
        super(httpClient, environment.apiUrl + '/berths')
    }

    public getForBrowser(): Observable<BerthAutoCompleteVM[]> {
        return this.http.get<BerthAutoCompleteVM[]>(environment.apiUrl + '/berths/getForBrowser')
    }

}
