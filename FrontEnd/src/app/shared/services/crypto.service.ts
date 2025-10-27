import { Injectable } from '@angular/core'
import *  as CryptoJS from 'crypto-js'

@Injectable({ providedIn: 'root' })

export class CryptoService {

    private key = '123'

    constructor() { }

    public encrypt(txt: string): string {
        return CryptoJS.AES.encrypt(txt.toString(), this.key).toString()
    }

    public decrypt(txtToDecrypt: string): string {
        return CryptoJS.AES.decrypt(txtToDecrypt, this.key).toString(CryptoJS.enc.Utf8)
    }

}
