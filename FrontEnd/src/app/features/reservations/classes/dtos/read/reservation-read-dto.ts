import { Metadata } from 'src/app/shared/classes/metadata'
import { ReservationBerthReadDto } from './reservation-berth-read-dto'
import { ReservationBoatReadDto } from './reservation-boat-read-dto'

export interface ReservationReadDto extends Metadata {

    reservationId: string
    boat: ReservationBoatReadDto
    berths: ReservationBerthReadDto[]
    fromDate: string
    toDate: string
    days: number
    isPassingBy: boolean
    isDocked: false,
    isDryDock: false,
    isDeleted: false,
    postAt: string
    postUser: string
    putAt: string
    putUser: string

}
