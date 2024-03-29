import { Component, OnInit } from '@angular/core';
import { Subject, BehaviorSubject, ReplaySubject, AsyncSubject, Subscription } from 'rxjs';

@Component({
    selector: 'app-my',
    templateUrl: './my.component.html',
    styleUrls: ['./my.component.css']
})
export class MyComponent implements OnInit {
    title = 'My Component';

    /*
    I Subjects sono sia Observables che Observer
    */

    // Oggetto Subject
    mySubject = new Subject<string>();

    // Emissione dati mediante metodo next() del Subject
    subjectEmit() {
        const value = 'Aldo';        
        this.mySubject.next(value);
        console.log('Subject Emit: ' + value);        
    }
    // Sottoscrizione dello stesso Subject
    subjectSubscribe() {
        //console.log('Start Subscribe Subject');
        this.mySubject
            .subscribe({
                next: data => console.log('Subject Suscribe: ' + data),
                // error: Error
                // complete: Complete
            });
    }

    /* BehaviorSubject
    Sottoscrivendo un BehaviorSubject, si ottiene l'ultimo valore da questo emesso.
    Necessita di almeno un valore iniziale
    */
    myBehaviorSubject = new BehaviorSubject<string>('Aldo');
    // Emissione
    behaviorSubjectEmit() {
        const value = 'Giovanni';
        console.log('Behavior Subject Emit: ' + value);
        this.myBehaviorSubject.next(value);
    }
    // Sottoscrizione
    behaviorSubjectSubscribe() {
        this.myBehaviorSubject
        .subscribe({
            next: data => console.log('Behavior Subject Suscribe: ' + data),
            // error: Error
            // complete: Complete
        });
    }

    /* Replay Subjects
    Restituisce gli ultimi n valori tenuti in memoria
    */
    myReplaySubject = new ReplaySubject<string>(2);
    // Emissione
    replaySubjectEmit() {
        // Emette gli elementi della serie ad ogni next()
        console.log('Replay Subject Emit');
        this.myReplaySubject.next('Giacomo 1');
        this.myReplaySubject.next('Giacomo 2');
        this.myReplaySubject.next('Giacomo 3');
        // Inizia la sottoscrizione
        this.replaySubjectSubscribe();
        // Continua a emettere la serie
        this.myReplaySubject.next('Giacomo 4');
        this.myReplaySubject.next('Giacomo 5');
        this.myReplaySubject.next('Giacomo 6');
    }
    // Sottoscrizione
    replaySubjectSubscribe() {
        this.myReplaySubject
        .subscribe({
            next: data => console.log('Replay Subject Suscribe: ' + data),
            // error: Error
            // complete: Complete
        });
    }

    /* AsyncSubject
    Variante in cui solo l'ultimo valore dell'Observable è inviato ai suoi osservatori
    e solo quando l'esecuzione è Complete
    */
    myAsyncSubject = new AsyncSubject<any>();
    // Emissione
    asyncSubjectEmit() {
        // Primo sottoscrittore
        this.asyncSubjectSubscribe();
        console.log('asyncSubjectSubscribe 1');
        // Emette gli elementi della serie ad ogni next()
        this.myAsyncSubject.next(1);
        this.myAsyncSubject.next(2);
        // Secondo sottoscrittore
        this.asyncSubjectSubscribe();
        console.log('asyncSubjectSubscribe 2');
        // Continua a emettere la serie
        this.myAsyncSubject.next(3);
        this.myAsyncSubject.next(4);
        // Quando il flusso è completo, l'ultimo valore emesso viene inviato ai sottoscrittori
        this.myAsyncSubject.complete();
    }
    // Sottoscrizione
    asyncSubjectSubscribe() {
        this.myAsyncSubject
        .subscribe({
            next: data => console.log('Async Subject Suscriber: ' + data),
            // error: Error
            // complete: Complete
        });
    }

    /* Esempio di Unsubscribe di Subject */
    public mySubscription: Subscription | undefined;
    mySubjectSubscription() {
        this.mySubscription = this.mySubject.subscribe({
            next: data => console.log('Subject Suscribe: ' + data),
            error: error => console.log(error),
            complete: () => console.log('Completed')
        });
    }
    mySubjectUnsubscription() {
        this.mySubscription?.unsubscribe();
    }

    ngOnInit() {
        // Chiama i sottoscrittori ai diversi tipi di Subject
        //this.subjectSubscribe();
        //this.behaviorSubjectSubscribe();
        //this.asyncSubjectSubscribe()
        //this.mySubjectSubscription();
    }

}
