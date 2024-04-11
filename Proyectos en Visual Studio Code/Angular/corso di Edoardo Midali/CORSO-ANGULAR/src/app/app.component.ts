import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ProvaComponent } from "./prova/prova.component";
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import {MatInputModule} from '@angular/material/input';

@Component({
    selector: 'app-root',
    standalone: true,
    templateUrl: './app.component.html',
    styleUrl: './app.component.css',
    imports: [RouterOutlet, ProvaComponent,MatButtonModule,MatCardModule,MatInputModule]
})
export class AppComponent {
  title = 'CORSO-ANGULAR';

  onInput(e:Event){
    this.title = (<HTMLInputElement>e.target).value;
  }
  onClick(e:AppComponent){
    console.log(e)
  }
}
