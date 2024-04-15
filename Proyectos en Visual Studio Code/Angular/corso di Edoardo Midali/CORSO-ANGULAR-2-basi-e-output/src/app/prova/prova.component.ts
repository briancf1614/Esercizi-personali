import { AfterViewInit, ElementRef, EventEmitter, Input, OnInit, ViewChild, viewChild } from '@angular/core';
import { Output } from '@angular/core';
import { Component } from '@angular/core';
import { HighlightDirective } from '../direttive/highlight.directive';

@Component({
  selector: 'app-prova',
  standalone: true,
  imports: [HighlightDirective],
  templateUrl: './prova.component.html',
  styleUrl: './prova.component.css'
})
export class ProvaComponent implements OnInit,AfterViewInit{



  @Input() pippo :any;
  @Output() mandaDatiEvento = new EventEmitter<string>();
  texto='';
  send($event: Event) {
    this.texto=(<HTMLInputElement>$event.target).value;
    this.mandaDatiEvento.emit(this.texto);
  }

  @ViewChild('inputSaluti') inputSaluti!:ElementRef<HTMLInputElement>
  ngOnInit(): void {
    console.log("oninit")
    console.log(this.inputSaluti)
  }
  ngAfterViewInit(): void {
    console.log(this.inputSaluti)
    console.log("after on view")
  }
  onClick() {
    // cosi vedo il valore del elemento
    console.log(this.inputSaluti.nativeElement.value)
  }
}
