import { Component } from '@angular/core';
import { User } from './user';
import { Logged } from './logged';
import { HttpClient } from '@angular/common/http';
import { Risposta } from './risposta';
import { HttpService } from './http.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = '05_MyForm_DELETE';

  user: User = { nome: '', password: '', email: '', hobby: '' };
  hobbies: string[] = ['Nuoto', 'Musica', 'Cucina'];    
  logged: Logged = { log:'', id:'', nome:'' };
  // Url della API
  url: string = 'https://ugobetori.it/_notes/api-test/angular/angular2/login.php';
  urlRisposta: string = 'https://ugobetori.it/_notes/api-test/angular/angular2/users.php';
  // Inietta istanza di Http 
  Risposta:Risposta[] | undefined;
  constructor(private httpClient: HttpClient,private httpService: HttpService) { }

// Invio dati
  submitTemplateForm() {
      // Confeziona i dati del form in formato JSON
      const datiJSON = {            
          nome: this.user.nome,
          password: this.user.password,

      };

      // Stringhifica l'oggetto JSON (in questo caso per soddisfare le esigenze del mio endpoint)    
      const datiStringa = JSON.stringify(datiJSON);
      // Http fornisce metodi per effettuare richieste HTTP restituisce un'Observable che apre un canale continuo di comunicazione
      // this.httpClient.post<Logged>(this.url, datiStringa)
      this.httpClient.post<Logged>(this.url, datiStringa)
      // this.httpService.postData(this.url,datiStringa)
      // Nel nostro esempio assegniamo il response a una proprietà del componente
      .subscribe({
          next: response => {
              this.logged = response;
              this.riceviDato();
              console.log('next: ' + JSON.stringify(this.logged));          
          },
          error: error => console.log('error: ' + error),
          complete: () => console.log('complete')
      });
      
  }


  riceviDato(){


    if(this.logged.log=='Si'){
      this.httpClient.get<Risposta[]>(this.urlRisposta)
      
      // Nel nostro esempio assegniamo il response a una proprietà del componente
      .subscribe({
          next: response => {
              this.Risposta = response;
              console.log('next: ' + JSON.stringify(this.Risposta));          
          },
          error: error => console.log('error: ' + error),
          complete: () => console.log('complete')
      });
    }
  }
    
  
}
