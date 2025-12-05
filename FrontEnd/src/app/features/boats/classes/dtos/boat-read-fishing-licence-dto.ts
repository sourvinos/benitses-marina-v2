import { Metadata } from 'src/app/shared/classes/metadata'

export interface BoatReadFishingLicenceDto extends Metadata {

    id: number
    boatId: number
    issuingAuthority: string
    licenceNo: string
    expireDate: string

}
