import { Component, Input, OnInit } from '@angular/core';
import { Utente } from './utente';

// Accede alla rotta attiva
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-due',
    templateUrl: './due.component.html',
    styleUrls: ['./due.component.css']
})

export class DueComponent implements OnInit {
    title = 'Component Due';

    utenti: Utente[] = [
        { id: '1', nome: 'Aldo', cognome: 'Rossi', motto: 'All is gone away' },
        { id: '2', nome: 'Giovanni', cognome: 'Verdi', motto: 'Per aspera ad astra' },
        { id: '3', nome: 'Giacomo', cognome: 'Bianchi', motto: 'Less is more' },
        { id: '4', nome: 'Ajeje', cognome: 'Brazorf', motto: 'Coraggio, il meglio è passato' }
    ];

    myId!: string;

    // Binding con gli @input() dei componenti: semplifica la trasmissione/ricezione di dati tra componenti
    @Input() id!: string;    
    // Versione alternativa con nomi identici
    //@Input('id') myIdBinding!: string; 
    

    // Inietta ActivatedRoute
    constructor(private activatedRoute: ActivatedRoute) {
        console.log('Costruttore Due Component');
    }

    ngOnInit() {
        console.log('OnInit Due Component');
        /* ActivatedRoute fornisce informazioni, tutte in forma di Observable, sulla rotta attiva tra queste: 
        paramMap, queryParams, fragment, data 
        */        
        // ParamMap
        this.activatedRoute.paramMap
        .subscribe({
            next: myParamMap => { 
                console.log('ParamMap: ', myParamMap);    
                console.log('id: ', myParamMap.get('id')); 
                console.log('nome: ', myParamMap.get('nome'));            
                if(myParamMap.get('id')) {                    
                    this.myId = myParamMap.get('id')!;
                }         
            },
            error: error => console.log('Error: ' + error),
            complete: () => console.log('Complete')
        });
       
        // QueryParams
        this.activatedRoute.queryParams
        .subscribe({
            next: myQueryParams => {        
                console.log('QueryParams: ', myQueryParams);
                console.log('id: ', myQueryParams['id']); 
                console.log('nome: ', myQueryParams['nome']);   
                if(myQueryParams['id']) {                    
                    this.myId = myQueryParams['id']; 
                } 
            },
            error: error => console.log('Error: ' + error),
            complete: () => console.log('Complete')
        });

        // Binding con @input()
        console.log('@input() id: ', this.id);       
    }

    ngOnDestroy() {
        console.log('OnDestroy Due Component');
    }
}
