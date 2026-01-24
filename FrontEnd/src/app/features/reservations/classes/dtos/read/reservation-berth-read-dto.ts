import { SimpleEntity } from "src/app/shared/classes/simple-entity"

export interface ReservationBerthReadDto {

    id: number
    reservationId: string
    berth: SimpleEntity

}
