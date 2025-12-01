import { Injectable } from '@angular/core'
import { Observable, of } from 'rxjs'
import { catchError, map } from 'rxjs/operators'
// Custom
import { BoatHttpService } from '../services/boat-http.service'
import { ListResolved } from '../../../../../shared/classes/list-resolved'

@Injectable({ providedIn: 'root' })

export class BoatListResolver {

    constructor(private boatHttpService: BoatHttpService) { }

    resolve(): Observable<ListResolved> {
        return this.boatHttpService.getAll().pipe(
            map((x) => new ListResolved(x)),
            catchError((err: any) => of(new ListResolved(null, err)))
        )
    }

}
