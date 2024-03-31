import { Injectable } from '@angular/core';

/* Subjects in RxJS
Il principale utilizzo previsto per i subjects è il multicasting:
ottenere cioé notifiche da una singola fonte observable e inoltrarle
a uno o più observer di destinazione.
Questa connessione di observer ad un observable è ciò che caratterizza
i subjects: sono in grado di farlo inquanto sono sia observable che observer.
*/
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class MyService {

  private myBSubjects = new BehaviorSubject<any>([]);
  myBSubject = this.myBSubjects.asObservable();

  constructor() { }

  changeSubject(myBSubject: any) {
    this.myBSubjects.next(myBSubject);
  }

}
