import { BoatWriteFishingLicenceDto } from "./boat-write-fishing-licence-dto"
import { BoatWriteInsuranceDto } from "./boat-write-insurance-dto"

export interface BoatWriteDto {

    id: number
    description: string
    boatUsageId: number,
    hullTypeId: number
    nationalityId: number
    insurance: BoatWriteInsuranceDto
    fishingLicence: BoatWriteFishingLicenceDto
    loa: string
    beam: string
    draft: string
    registryPort: string
    registryNo: string
    isAthenian: boolean
    isFishingBoat: boolean
    isActive: boolean
    putAt: string

}
