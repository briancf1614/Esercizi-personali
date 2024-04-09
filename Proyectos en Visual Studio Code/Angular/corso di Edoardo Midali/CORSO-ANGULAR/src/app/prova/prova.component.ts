import { AfterContentChecked, AfterContentInit, AfterViewChecked, AfterViewInit, Component, DoCheck, OnDestroy, OnInit } from '@angular/core';

@Component({
  selector: 'app-prova',
  standalone: true,
  imports: [],
  templateUrl: './prova.component.html',
  styleUrl: './prova.component.css'
})
export class ProvaComponent implements OnInit,AfterContentChecked, AfterContentInit, AfterViewChecked, AfterViewInit, DoCheck,OnDestroy{
  constructor() {
    console.log("costruttore")
  }
  ngOnInit(): void {
    console.log("ngOnInit")
  }
  ngAfterContentChecked(): void {
    console.log("ngAfterContentChecked")
  }
  ngAfterContentInit(): void {
    console.log("ngAfterContentInit")
  }
  ngAfterViewChecked(): void {
    console.log("ngAfterViewChecked")
  }
  ngAfterViewInit(): void {
    console.log("ngAfterViewInit")
  }
  ngDoCheck(): void {
    console.log("ngDoCheck")
  }
  ngOnDestroy(): void {
    console.log("ngOnDestroy")
  }
}
