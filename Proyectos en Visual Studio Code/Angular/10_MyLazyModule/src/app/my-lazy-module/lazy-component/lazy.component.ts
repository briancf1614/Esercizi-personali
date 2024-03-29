import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-lazy',
  templateUrl: './lazy.component.html',
  styleUrls: ['./lazy.component.css']
})
export class LazyComponent implements OnInit {

  title = 'My Lazy Component';
  constructor() {
    console.log('Constructor componente lazy');
   }

  ngOnInit(){
    console.log('OnInit componente lazy');
  }

  ngOnDestroy() {
    console.log('OnDestroy componente lazy');
  }

}
