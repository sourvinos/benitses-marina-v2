import { SimpleEntity } from "src/app/shared/classes/simple-entity"
import { BoatReadFishingLicenceDto } from "../dtos/boat-read-fishing-licence-dto"
import { BoatReadInsuranceDto } from "../dtos/boat-read-insurance-dto"

export interface BoatBrowserListVM {

    beam: string
    boatUsage: SimpleEntity
    description: string
    draft: string
    fishingLicence: BoatReadFishingLicenceDto
    flag: string
    hullType: SimpleEntity
    id: number
    insurance: BoatReadInsuranceDto
    isActive: boolean
    isAthenian: boolean
    isFishingBoat: boolean
    loa: string
    postAt: string
    postUser: string
    putAt: string
    putUser: string
    registryNo: string
    registryPort: string
    
}
