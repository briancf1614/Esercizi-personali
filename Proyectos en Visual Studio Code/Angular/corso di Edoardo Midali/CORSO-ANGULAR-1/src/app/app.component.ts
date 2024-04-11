import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ProvaComponent } from "./prova/prova.component";
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import {MatInputModule} from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
    selector: 'app-root',
    standalone: true,
    templateUrl: './app.component.html',
    styleUrl: './app.component.css',
    imports: [RouterOutlet, ProvaComponent,MatButtonModule,MatCardModule,MatInputModule,FormsModule,CommonModule]
})
export class AppComponent {

  title = 'CORSO-ANGULAR';
  isVisible = false;
  persone = [
    {nome:"Luca",cognome:"verdi",isOnline:true},
    {nome:"brian",cognome:"verdi",isOnline:false},
    {nome:"paul",cognome:"verdi",isOnline:true},
    {nome:"Brandon",cognome:"verdi",isOnline:false}
  ]
numero=3;
  onInput(e:Event){
    this.title = (<HTMLInputElement>e.target).value;
  }
  onClick(event:Event){
    this.title = "he presionado el button"
  }
  changes() {
    this.persone = [
      {nome:"blabla",cognome:"verdi",isOnline:true},
      {nome:"asdfsda",cognome:"verdi",isOnline:false},
      {nome:"psdgfwraul",cognome:"verdi",isOnline:true},
      {nome:"werw",cognome:"verdi",isOnline:false}
    ]
  }
}
