import { Injectable } from '@angular/core';
//import { MyFeatureModule1 } from './my-feature1.module';

/*
// N.B. Il modulo specificato non può essere un modulo che dichiara un componente che utilizza il service
*/
@Injectable(
   /*{  
    //provideIn: 'root'  
    providedIn: MyFeatureModule1
    }*/
)

export class MyService {
    constructor() {
        console.log('My Service Constructor');
    }
    // Metodo
    myServiceMethod(): string {
        return '1234567890';
    }
}
