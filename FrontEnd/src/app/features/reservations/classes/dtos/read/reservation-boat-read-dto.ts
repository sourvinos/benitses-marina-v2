import { ReservationBoatInsuranceReadDto } from './reservation-boat-insurance-read-dto'
import { ReservationBoatNationalityReadDto } from './reservation-boat-nationality-read-dto'
import { SimpleEntity } from 'src/app/shared/classes/simple-entity'

export interface ReservationBoatReadDto {

    reservationId: string
    id: number
    description: string
    hullType: SimpleEntity
    usage: SimpleEntity
    nationality: ReservationBoatNationalityReadDto
    insurance: ReservationBoatInsuranceReadDto
    loa: number
    beam: number
    draft: number
    registryPort: string
    registryNo: string

}
