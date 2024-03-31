import { Component, ViewChild, ElementRef } from '@angular/core';

// Importa Intefaccia TypeScript
import { MyInterface } from './my-interface';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})

export class AppComponent {
    title: string = 'My Template';

    myImgUrl: string = './assets/myimg.jpg';
    myNum: number = 3;
    myNum2: number = 0;
    myBoolean: boolean = true;
    myModel: string = 'MyModel Ciao';
    myNames: string[] = ['Al', 'Joe', 'Jack'];

    myObject: any = { nome: 'Aldo', cognome: 'Rossi', eta: 33 };
    myObjects: any[] = [
        { id: 1, nome: 'Aldo', cognome: 'Rossi', eta: 33 },
        { id: 2, nome: 'Giovanni', cognome: 'Verdi', eta: 44 },
        { id: 3, nome: 'Giacomo', cognome: 'Bianchi', eta: 55 }
    ];

    myInterface: MyInterface = { id: 1, nome: 'Alda', cognome: 'Rossa', eta: 44 };    
    myInterfaces: MyInterface[] = [
        { id: 1, nome: 'Alda', cognome: 'Rossi', eta: 33 },
        { id: 2, nome: 'Giovanna', cognome: 'Verdi', eta: 44 },
        { id: 3, nome: 'Giacomina', cognome: 'Bianchi', eta: 55 },
    ];

    mySize = 12;
    myCssClass = 'myBlue';
  
    doubleMyNum() {
        return this.myNum * 2;
    }
    showRef(ref: any) {
        window.alert(ref);
    }
}
