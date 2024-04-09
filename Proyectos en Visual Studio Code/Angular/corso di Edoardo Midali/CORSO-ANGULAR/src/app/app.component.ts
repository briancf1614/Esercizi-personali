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
  title = 'CORSO-ANGULAR';
}
