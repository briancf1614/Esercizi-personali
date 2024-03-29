import { Component, OnInit } from '@angular/core';

import { Observable, connectable } from 'rxjs';
import { connect } from 'rxjs/operators';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
    title = 'My Subject';

    /* Cold Observable
    Il codice viene eseguito e i valori emessi quando c'è almeno un subscriber che li chiede
    Ogni sottoscrittore invoca la creazione di una nuova istanza dell'Observable
    */
    myColdObservable$ = new Observable(observer => {
        setTimeout(() => {
            observer.next(1);
        }, 1000);
        setTimeout(() => {
            observer.next(2);
        }, 2000);
        setTimeout(() => {
            observer.next(3);
        }, 3000);
        setTimeout(() => {
            observer.next(4);
        }, 4000);
    });

    /* Hot Observable
    Il codice viene eseguito e i valori vengono emessi anche se non è presente alcun subscriber
    Tutti i sottoscrittori condividono una singola esecuzione dell'Observable
    */
    myHotObservable$ = connectable(this.myColdObservable$)

    // Esempio di sottoscrittori
    mySubscribers() {
        /* Cold Observable 
        Inizia a emettere oggetti quando è sottoscritto.
        Ogni subscriber ottiene una nuova istanza dell'observable
        
        // Sottoscrittore A
        this.myColdObservable$.subscribe({
            next: value => console.log('Cold Subscriber A: ' + value),
            // error: ...
            // complete: ...
        });

        // Sottoscrittore B
        // setTimeout(funzioneDaEseguire(), ritardo in ms)
        setTimeout(() => {
            this.myColdObservable$.subscribe(
                {
                    next: value => console.log('Cold Subscriber B: ' + value),
                    // error: ...
                    // complete: ...
                }
            );
        }, 2000
        );
        */

        /* HotObservable (multicast)
        Inizia a emettere oggetti quando viene applicato l'operatore Connect 
        il quale sottoscrive il Subject e lo serve ai Subscribers.
        Ogni subscriber ottiene valori di un'unica istanza dell'Observable a partire dal momento della sottoscrizione 
        */
        // Sottoscrittore A
        this.myHotObservable$.subscribe({
            next: value => console.log('Hot Subscriber A: ' + value), 
            // error: ...
            // complete: ...
        })
        // Sottoscrittore B
        setTimeout(() => {
          this.myHotObservable$.subscribe({
            next: value => console.log('- Hot Subscriber B: ' + value),
            // error: ...
            // complete: ...
          })
        }, 3000
        );

        // L'hot Observable inizia a emettere valori chiamando esso stesso il mettodo connect()
        setTimeout(() => { 
            this.myHotObservable$.connect()
        }, 
        0);  
                     
    }
    ngOnInit() {
       // this.mySubscribers();
    }
}
