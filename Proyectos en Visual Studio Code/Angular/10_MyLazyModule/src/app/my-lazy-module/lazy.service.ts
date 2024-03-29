import { Injectable } from '@angular/core';

@Injectable(
    /*{ providedIn: 'root' }*/
)
export class LazyService {

    public testoService = 'Proprietà del Service lazy';

    constructor() {
        console.log('Costruttore del Service lazy');
    }
    public metodoService() {
        console.log('Metodo del Service Lazy');
    }
}
