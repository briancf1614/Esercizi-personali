import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ProvaComponent } from "./prova/prova.component";

@Component({
    selector: 'app-root',
    standalone: true,
    templateUrl: './app.component.html',
    styleUrl: './app.component.css',
    imports: [RouterOutlet, ProvaComponent]
})
export class AppComponent {
  riceviDati() {
  throw new Error('Method not implemented.');
  }
  title = 'CORSO-ANGULAR-2-basi-e-output';
algo: any;
}
