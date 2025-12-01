// Custom
import { Metadata } from 'src/app/shared/classes/metadata'

export interface BoatReadDto extends Metadata {

    id: number
    description: string
    postAt: string
    postUser: string
    putAt: string
    putUser: string

}
