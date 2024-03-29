import { Component } from '@angular/core';

import { MyService } from './services/my.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  providers:[MyService]
})
export class AppComponent {
  title = '07_MyService_DELETE';
}
