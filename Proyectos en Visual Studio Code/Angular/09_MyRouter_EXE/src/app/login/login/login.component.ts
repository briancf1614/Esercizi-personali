import { Component } from '@angular/core';
import { LoginService } from '../login.service';
import { GlobalService } from '../../global.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  constructor(private loginService:LoginService,private globalService:GlobalService) {
    console.log('Costruttore Uno Component');
}
  
  // Url della API
  url: string = 'https://ugobetori.it/_notes/api-test/angular/angular2_unauth/login.php';

  password:string='';
  name!:string;
// Invio dati
  submitTemplateForm() {
      // Confeziona i dati del form in formato JSON
      const datiJSON = {            
          name: this.name,
          password: this.password,

      };

      // Stringhifica l'oggetto JSON (in questo caso per soddisfare le esigenze del mio endpoint)    
      const datiStringa = JSON.stringify(datiJSON);
      // Http fornisce metodi per effettuare richieste HTTP restituisce un'Observable che apre un canale continuo di comunicazione
      
      this.loginService.httpPostLogin(this.url,datiStringa)
      // Nel nostro esempio assegniamo il response a una proprietà del componente
      .subscribe({
          next: response => {
              this.globalService.logged = response;

              console.log(JSON.stringify(this.globalService.logged));          
          },
          error: error => console.log('error: ' + error),
          complete: () => console.log('complete')
      });
      
  }


  // riceviDato(){


  //   if(this.logged.log=='Si'){
  //     this.httpClient.get<Risposta[]>(this.urlRisposta)
      
  //     // Nel nostro esempio assegniamo il response a una proprietà del componente
  //     .subscribe({
  //         next: response => {
  //             this.Risposta = response;
  //             console.log('next: ' + JSON.stringify(this.Risposta));          
  //         },
  //         error: error => console.log('error: ' + error),
  //         complete: () => console.log('complete')
  //     });
  //   }
  // }





}
