import { UpperCasePipe } from '@angular/common';
import { Component } from '@angular/core';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = '03_MyPipe_test';


  myText: string = "testo tutto minuscolo";
  myDate: Date = new Date(1977, 11, 12);
  myPrice: number = 65.43216;
  myProfit: number = 0.37;
  myName: string = 'Giacomo';    
  myJsonObject: any = {
      name: 'Mario',
      surname: 'Viola',
      details: {
          age: 33,
          quality: ['Bello', 'Alto', 'Onesto']
      }
  };
  myObject: any = { nome: 'Fragole', prezzo: 7 };
  myMap: any = new Map([[1, 'Arance'], [2, 'Broccoli']]);
  
  myObservable$ = new Observable(observer => {
    setTimeout(() => {
        observer.next('Aldo');
    }, 0);
    setTimeout(() => {
        observer.next('Bice');
    }, 2000);
    setTimeout(() => {
        observer.next('Ciro');
    }, 4000);
    setTimeout(() => {
        observer.next('Dudù');
    }, 6000);
});
// Proprietà per le pipe custom
myString = 'Mia stringa';
myArray = ['Aldo', 'Giovanni', 'Giacomo', 'Giacomino', 'Giacomone', 'Giacomissimo', 'Giacomissimone', 'Giacomissimissimo'];

// Proprietà per pipe via model
testoPipeModel = "testo per pipe via model";

// Le pipe builtin vanno importate come Service a livello di modulo
// constructor(private upperCasePipe: UpperCasePipe) {
//   this.testoPipeModel = upperCasePipe.transform(this.testoPipeModel);
// }

}
