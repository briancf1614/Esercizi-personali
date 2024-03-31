import { Component, OnInit } from '@angular/core';

// Accede alla rotta attiva
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-tre-uno',
    templateUrl: './tre-uno.component.html',
    styleUrls: ['./tre-uno.component.css']
})
export class TreUnoComponent implements OnInit {

    title = 'Component Tre Uno';

    // Inietta ActivatedRoute
    constructor(private activatedRoute: ActivatedRoute) {
        console.log('Costruttore TreUno Component');
    }

    ngOnInit() {
        console.log('ActivatedRoute TreUno data: ', 
        this.activatedRoute.snapshot.data['mydata1'], 
        this.activatedRoute.snapshot.data['mydata2']
        );
    }

}
