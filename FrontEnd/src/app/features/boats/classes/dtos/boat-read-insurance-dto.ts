import { Metadata } from 'src/app/shared/classes/metadata'

export interface BoatReadInsuranceDto extends Metadata {

    id: number
    boatId: number
    company: string
    contractNo: string
    expireDate: string

}
