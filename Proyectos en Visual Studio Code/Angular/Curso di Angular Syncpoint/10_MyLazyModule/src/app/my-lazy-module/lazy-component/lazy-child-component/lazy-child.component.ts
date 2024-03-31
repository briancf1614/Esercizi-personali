import { Component, OnInit } from '@angular/core';

// Service del modulo lazy
import {LazyService} from '../../lazy.service';

@Component({
  selector: 'app-lazy-child',
  templateUrl: './lazy-child.component.html',
  styleUrls: ['./lazy-child.component.css']
})

export class LazyChildComponent implements OnInit {

  title = 'My Lazy Child Component';
  
  users = [
    { name: 'Aldo Rossi' },
    { name: 'Giovanni Verdi' },
    { name: 'Giacomo Bianchi' }
  ];

  constructor(public lazyService: LazyService) {
   }

   ngOnInit(){
     console.log('Componente child lazy inizializzato');
   }

}
