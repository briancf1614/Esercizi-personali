import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = '09_MyRouter';
  paramMap: any = { id: 3, nome: 'Mara' };
  queryParams: any = { id: 4, nome: 'Ciro' };

}
