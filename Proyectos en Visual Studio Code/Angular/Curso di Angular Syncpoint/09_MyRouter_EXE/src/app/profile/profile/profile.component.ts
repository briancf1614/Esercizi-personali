import { Component } from '@angular/core';
import { ProfileService } from '../profile.service';
import { GlobalService } from '../../global.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.css'
})
export class ProfileComponent {

url1:string ='https://ugobetori.it/_notes/api-test/angular/angular2_unauth/select_profile.php?id=';
url2:string ='https://ugobetori.it/_notes/api-test/angular/angular2_unauth/manage_profile.php';
notes:any;

note!:string;
  constructor(private profileService:ProfileService,private globalService:GlobalService) {
    console.log('Costruttore network Component');
}



  getProfile(){
      
    this.profileService.httpGetProfile(this.url1+this.globalService.logged.id)
    // Nel nostro esempio assegniamo il response a una proprietà del componente
    .subscribe({
        next: response => {
            this.notes = response;

            console.log(this.notes);          
        },
        error: error => console.log('error: ' + error),
        complete: () => console.log('complete')
    });
    

  }

  addNote(){
    let jsonData = {
      "id_user": this.globalService.logged.id,
      "note": this.note
  }
  let stringData = JSON.stringify(jsonData);
    this.profileService.httpAddNote(this.url2,stringData)
    .subscribe({
      next: response => {


          console.log(response);
          if(response["response"] === "Ok insert"){
            this.getProfile();
          }else{
            console.log("errore insert add note" + JSON.stringify(response))
          }
          

      },
      error: error => console.log('error: ' + error),
      complete: () => console.log('complete')
  });

  }
  removeNote(id:string){
    this.profileService.httpRemoveNote(this.url2,id)
    .subscribe({
      next: response => {


          console.log(response);   
          if(response["response"] == "Ok delete"){
            this.getProfile();   
          }else{
            console.log("errore delete note" + response)
          }
              
      },
      error: error => console.log('error: ' + error),
      complete: () => console.log('complete')
  });
  }






ngOnInit(){
  this.getProfile();
}





}
