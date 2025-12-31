import { ReservationListBerthVM } from './reservation-list-berth-vm'
import { ReservationListBoatVM } from './reservation-list-boat-vm'

export interface ReservationListVM {

    reservationId: string
    boat: ReservationListBoatVM
    fromDate: string
    toDate: string
    berths: ReservationListBerthVM[]
    joinedBerths: string
    isAthenian: boolean
    isFishingBoat: boolean
    isDocked: boolean
    isDryDock: boolean
    isPassingBy: boolean
    isOverdue: boolean

}
