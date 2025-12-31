import { SimpleEntity } from "src/app/shared/classes/simple-entity"

export interface ReservationListBoatVM {

    id: number
    type: SimpleEntity
    description: string
    loa: string
    beam: string

}
