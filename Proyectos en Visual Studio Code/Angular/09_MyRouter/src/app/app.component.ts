import { Component } from '@angular/core';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {
    title: string = 'My Router';
    
    // Parametri inviati
    myParamMap: any = { id: 3, nome: 'Mara' };
    myQueryParams: any = { id: 4, nome: 'Ciro' };
    // Per canActivate
    guardRole: any = { role: 'Admin' };

    ngOnInit() {
        console.log('OnInit App');
    }
}
