import { ReservationBerthWriteDto } from "./reservation-berth-write-dto"

export interface ReservationWriteDto {

    reservationId: string
    boatId: number
    fromDate: string
    toDate: string
    days: number
    berths: ReservationBerthWriteDto[]
    putAt: string

}
