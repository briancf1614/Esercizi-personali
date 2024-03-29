import { Component, OnInit } from '@angular/core';
import { LoggedService } from 'src/app/service/logged.service';

@Component({
    selector: 'app-tre-due',
    templateUrl: './tre-due.component.html',
    styleUrls: ['./tre-due.component.css']
})

export class TreDueComponent implements OnInit {
    title = 'Component Tre Due';

    constructor(private loggedService: LoggedService) {
        console.log('Costruttore TreDue Component');
    }
    saveData() {
        // Codice di salvataggio dati (es. http.post verso server, o in browser storage)
        // ...
        // Quindi modifica il valore che determina il comportamento della guard
        this.loggedService.deactivate = false;
    }
    ngOnInit() {
    }

}
