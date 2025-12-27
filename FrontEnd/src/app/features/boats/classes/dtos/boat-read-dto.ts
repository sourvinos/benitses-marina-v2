import { Metadata } from 'src/app/shared/classes/metadata'
import { SimpleEntity } from 'src/app/shared/classes/simple-entity'
import { BoatReadInsuranceDto } from './boat-read-insurance-dto'
import { BoatReadFishingLicenceDto } from './boat-read-fishing-licence-dto'

export interface BoatReadDto extends Metadata {

    id: number
    description: string
    boatUsage: SimpleEntity
    hullType: SimpleEntity
    nationality: SimpleEntity
    insurance: BoatReadInsuranceDto
    fishingLicence: BoatReadFishingLicenceDto
    loa: string
    beam: string
    draft: string
    registryPort: string
    registryNo: string
    isAthenian: boolean
    isFishingBoat: boolean
    isActive: boolean
    postAt: string
    postUser: string
    putAt: string
    putUser: string

}
