import Dexie from 'dexie'
import { Injectable } from '@angular/core'

@Injectable({ providedIn: 'root' })

export class DexieService extends Dexie {

    constructor() {
        super('Benitses-Marina-v2')
        this.version(1).stores({
            boatUsages: 'id, description',
            boats: 'id, description',
            hullTypes: 'id, description',
        })
        this.open()
    }

    public populateTable(table: string, httpService: any): void {
        httpService.getForBrowser().subscribe((records: any) => {
            this.table(table)
                .clear().then(() => {
                    this.table(table)
                        .bulkAdd(records)
                        .catch(Dexie.BulkError, () => { })
                })
        })
    }

    public populateCriteria(table: string, httpService: any): void {
        httpService.getForCriteria().subscribe((records: any) => {
            this.table(table)
                .clear().then(() => {
                    this.table(table)
                        .bulkAdd(records)
                        .catch(Dexie.BulkError, () => { })
                })
        })
    }

    public async getAll(table: string): Promise<any> {
        return await this.table(table).toArray()
    }

    public async getLast(table: string): Promise<any> {
        return await this.table(table).orderBy('id').last()
    }

    public async getById(table: string, id: number): Promise<any> {
        return await this.table(table).get({ id: id })
    }

    public async getByDescription(table: string, description: string): Promise<any> {
        return await this.table(table).get({ description: description })
    }

    public update(table: string, item: any): void {
        this.table(table).put(item)
    }

    public remove(table: string, id: any): void {
        this.table(table).delete(id)
    }

}

export const db = new DexieService()
