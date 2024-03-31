import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';

/*
RxJS (Reactive Extensions for JavaScript): libreria per la programmazione
reattiva che utilizza observable, facilita la composizione di codice asincrono.
RxJS fornisce un'implementazione del tipo Observable, necessario fino a quando
il tipo diventerà parte del linguagio e fino a quando i browser non lo
supportano. La libreria fornisce numerosi Operatori per la creazione,
la gestione e la manipolazione di observable.
Oggetti di RxJs
- Observable: rappresenta una raccolta invocabile di valori o eventi futuri
- Observer: è una raccolta di callback che sa come ascoltare i valori forniti dall'Observable
- Subscription: consente di attivare l'esecuzione di un Observable e di annullarla (un observable potenzialmente può emettere valori per sempre)
- Operators: funzioni pure che consentono di trattare le collezioni con operazioni di creazione, modifica, filtro, ecc.
- Subject: l'equivalente di un EventEmitter e l'unico modo per trasmettere in multicast un valore o un evento a più osservatori
- Scheduler: dispatcher centralizzati per controllare la concorrenza tra Observable
*/
// Oggetti
import { Observable, Observer, Subscription, combineLatest } from 'rxjs';

/* Operatori
Forniscono una soluzione elegante e dichiarativa a complessi compiti asincroni
Si possono raggruppare nelle seguenti categorie:
- Creation
- Combination
- Conditional
- Filtering
- Transformation
- Error Handling
- Utility
- Multicasting
*/

// Operatori
import { pipe, of, from, fromEvent, range, interval, concat, merge, throwError, timer } from 'rxjs';
import { first, take, map, filter, every, delay, catchError, finalize, retry, retryWhen, tap, delayWhen, mapTo, distinct, switchMap,  defaultIfEmpty, mergeWith, mergeMap } from 'rxjs/operators';
import { ajax } from 'rxjs/ajax';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {
    title: string = 'My Observable';

    test: any;

    myArray: Array<any> = ['A', 'B', 'C', 'D', 'E', 12, 'G'];

    myObject: any[] = [
        { nome: 'Aldo', eta: 33 },
        { nome: 'Giovanni', eta: 22 },
        { nome: 'Giacomo', eta: 33 }
    ];

    myObject2: any[] = [
        { nome: 'Alda', eta: 33 },
        { nome: 'Giovanni', eta: 22 },
        { nome: 'Giacomina', eta: 33 }
    ];
    
    /* Observable
    Un observable rappresenta un flusso o una fonte di dati che possono arrivare nel tempo.
    Un Observable emette valori all'observer attivato in fase di sottoscrizione
    */
    // Al costruttore dell'Observable viene passato un sottoscrittore/observer
    myObservable$ = new Observable(observer => {
        // Al sottoscrittore/observer vengono passati i valori via via emessi dall'Observable
        // L'esecuzione può produrre più valori nel tempo, in modo sincrono o asincrono.
        observer.next(1);
        observer.next(2);
        observer.next(3);
        // Esempio invio asincrono
        // setTimeout(funzioneDaEseguire(), ritardo)
        setTimeout(() => {
            observer.next(4);
        }, 2000);
        // Esempio generazione errore
        throw new Error('OPS!');
        observer.next(5);
        setTimeout(() => {
            observer.complete();
        }, 3000);
    });

    /* Observer
    Consumatore di valori forniti da un Observable. 
    Un insieme di callback, uno per ogni tipo di notifica fornita dall'observable
    */
    myObserver: Observer<any> = {
        next: value => console.log('Next: ' + value),
        error: error => console.error('Error: ' + error),
        complete: () => console.log('Complete!')
    };    

    /* Subscription
    Consente di attivare l'esecuzione di un Observable e di annullarla (un observable potenzialmente può emettere valori per sempre)
    */
    mySubscribtion!: Subscription;

    /* Operatori di creazione
    Consentono di creare observable da quasi tutto, il caso d'uso più comune in RxJS è da eventi
    come il movimento del mouse, i click sui pulsanti, l'input in un campo di testo, i cambiamenti di rotta, ecc.
    */
    myObservableOf$ = of(1, 2, 1, 3, 2, 4, 6);
    myObservableFrom$ = from(this.myArray);
    myObservableRange$ = range(9, 11);
    myObservableInterval$ = interval(1000);
    myObservableConcat$ = concat(this.myObservableFrom$, this.myObservableRange$);
    /*  Subscriber/Observer
    Per Ottenere i dati dall'observable è necessario sottoscriverne la trasmissione
    mediante il metodo subscribe(), che fornisce una funzione (o oggetto) observer
    Il metodo subscribe(), implementa l'interfaccia Observer, e usa callback per raccogliere gli eventi emessi dall'observable
    */
    mySubscribe() {
        this.myObservableConcat$
        /* Operatori
        Offrono modi per manipolare i valori da una fonte. Una volta trasformati i dati in ingresso
        li restistuiscono, grazie al metodo pipe(), ancora in forma di observable */
        .pipe(
            // first()
            // take(3)
            // Map, come in JavaScript, trasforma gli elementi emessi applicando ad ognuno una funzione
            //map(value => value * 100)
            // Filter emette solo i valori che rispondono a determinate condizioni
            // filter(value => value % 2 === 0)
            // Every emette true o false se tutti i valori soddisfano o meno una condizione
            // every(value => typeof value === 'string')
            // distinct filtra i valori in ingresso escludendo valori duplicati
            // distinct()    
            // CatchError gestisce gli errori restituendo un observable contenente il messaggio di errore
            // Es: genera un errore applicando toUppercase() ad un numero, quindi catchError() gestisce l'errore 
            // map(value => value.toLowerCase()),
            // catchError(error => of('F gestito'))
        )               
        .subscribe({
            next: value => console.log('Subscribe() next: ' + JSON.stringify(value)),
            error: error => console.error('Subscribe() error: ' + error),
            complete: () => console.log('Subscribe() completed\n----')
        });       
        //.subscribe(this.myObserver)
    }
    /* Gestione degli errori.   
    La gestione degli errori utilizzando la callback di errore a volte può essere sufficiente ma altre può risultare assai limitato. 
    Ad esempio, non possiamo recuperare l'errore o emettere un valore alternativo di fallback che sostituisca il valore che ci aspettavamo.
    Oltre al gestore error(), RxJS fornisce strumenti più avanzati:
    - catchError() è una funzione che accetta un input Observable e restituisce un output Observable.
    Rilevando l'errore e fornendo  un valore predefinito, lo stream continua a elaborare i valori anziché generare errori. 
    - finalize() verrà eseguito indipendentemente se viene generato o meno un errore
    - retry() consente di ripetere la subscription e rieseguire la sequenza completa di azioni prevista
    */
    mySubscribeError() {
        this.myObservable$
        .pipe(
            // 1. catchError() accetta un input Observable e restituisce un output Observable
            catchError(error => of('catchError(): valore sostitutivo')),
            // finalize viene comunque eseguito
            // finalize(() => console.log("Finalized"))
            // 2. retry() retryWhen() consentono di richiamare l'Observable
            // retry(2)   
            /*     
            retryWhen(error => {
                return error
                .pipe(
                    // delayWhen() ritarda l'emissione di elementi dall'Observable per un periodo di tempo determinato dalle emissioni di un altro Observable        
                    delayWhen(() => timer(3000)),
                    // tap() esegue un effetto collaterale (qui console.log()) per ogni emissione dell'Observable, 
                    tap(() => console.log('Riprovo...'))
                );
            })  
            */                             
        )
        .subscribe({
            next: value => console.log('Next:' + value),
            error: error => console.log('Error: ' + error.message),
            complete: () => console.log('Completed')
        });
    }

    // Uso di Subscription 
    mySubscriber() {
        this.mySubscribtion = this.myObservableInterval$.subscribe(this.myObserver);
    }
    myUnsubscriber() {
        this.mySubscribtion.unsubscribe();
    }

    /* Caso d'uso */
    // Parse JSON
    getCountries(code: string) {   
        ajax('https://restcountries.com/v3.1/all')        
        .pipe(
            // 1. Restituisce un nuovo observable per ogni item dell'observable
            switchMap(async (ajaxResponse) => ajaxResponse.response),
            switchMap((response: any | null) => response),
            // 2. Filtra i valori in base ad una condizione
            filter((response: any | null) => response['fifa'] === code),
            // 3. Accede alle proprietà annidate 
            map(country => country?.name?.common),
            // Valore di default in caso di mancato match con criteri di filtro
            defaultIfEmpty('Nazione non trovata')
        )       
        .subscribe({
            next: country => console.log(country),
            error: error => console.log(error),
            complete: () => console.log('Complete')
        });
    }
    
    ngOnInit() {
        // console.log("OnInit");        
        this.mySubscribe();
        //this.mySubscribeError();        
        //this.mySubscriber();     
        //this.getCountries('ITA');    
    }  

}