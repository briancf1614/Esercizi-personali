import { Component } from '@angular/core';
import { User } from './user';
import { Logged } from './logged';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'nuevoTest';



    user: User = { nome: '', password: '', email: '', hobby: '' };
    hobbies: string[] = ['Nuoto', 'Musica', 'Cucina'];
    logged: Logged = { log:'', id:'', nome:'' };
 
    // Url della API
    url: string = 'https://ugobetori.it/_notes/api-test/angular/angular2/login.php';

    constructor(private httpClient: HttpClient){}
    submitTemplateForm() {
      // Confeziona i dati del form in formato JSON
      const datiJSON = {            
          nome: this.user.nome,
          password: this.user.password,
          email: this.user.email,
          hobby: this.user.hobby
      };

      

      // Stringhifica l'oggetto JSON (in questo caso per soddisfare le esigenze del mio endpoint)    
      const datiStringa = JSON.stringify(datiJSON);
      // Http fornisce metodi per effettuare richieste HTTP restituisce un'Observable che apre un canale continuo di comunicazione
      this.httpClient.post<Logged>(this.url, datiStringa)
      /*
      subscribe() è l'observer che permette di ascoltare i dati del flusso, dispone di tre callback:
      - il primo (corrisponde all'evento onNext dell'observable) è invocato quando si ricevono nuovi valori,
      - il secondo (corrisponde all'evento onError)
      - l'ultimo (corrisponde all'evento onCompleted) è la funzione da richiamare quando la sequenza di dati in ingresso è completata con successo.
      */
      .subscribe({
          next: response => {
            this.logged = response;
            console.log('next: ' + JSON.stringify(this.logged));          
        },
          error: errore => console.log('error: ' + JSON.stringify(errore)),
          complete: () => console.log('complete')
      });


}


}