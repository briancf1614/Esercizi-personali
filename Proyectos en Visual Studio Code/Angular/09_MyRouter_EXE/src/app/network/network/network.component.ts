import { Component } from '@angular/core';
import { NetworkService } from '../network.service';
import { GlobalService } from '../../global.service';

@Component({
  selector: 'app-network',
  templateUrl: './network.component.html',
  styleUrl: './network.component.css'
})
export class NetworkComponent {

  constructor(private networkService:NetworkService,private globalService:GlobalService) {
    console.log('Costruttore network Component');
}

  // Url della API
  url: string = 'https://ugobetori.it/_notes/api-test/angular/angular2_unauth/select_users.php';
  url2: string = 'https://ugobetori.it/_notes/api-test/angular/angular2_unauth/img/';

  users!:any;


  // name:string;
  // surname;string;

    // Http fornisce metodi per effettuare richieste HTTP restituisce un'Observable che apre un canale continuo di comunicazione
    getNetwork(){
      
    this.networkService.httpGetNetwork(this.url)
    // Nel nostro esempio assegniamo il response a una proprietà del componente
    .subscribe({
        next: response => {
            this.users = response;

            console.log(this.users);          
        },
        error: error => console.log('error: ' + error),
        complete: () => console.log('complete')
    });
    

  }

ngOnInit(){
  this.getNetwork();
}

}
