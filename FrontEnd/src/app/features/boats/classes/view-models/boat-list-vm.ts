import { BoatListNationalityVM } from "./boat-list-nationality-vm"

export interface BoatListVM {

    id: number
    description: string
    nationality: BoatListNationalityVM
    loa: string
    beam: string
    registryNo: string
    isAthenian: boolean
    isFishingBoat: boolean
    isActive: boolean

}
