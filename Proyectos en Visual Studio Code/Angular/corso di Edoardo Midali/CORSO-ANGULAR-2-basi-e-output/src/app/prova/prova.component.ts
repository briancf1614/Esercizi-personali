import { EventEmitter } from '@angular/core';
import { Output } from '@angular/core';
import { Component } from '@angular/core';

@Component({
  selector: 'app-prova',
  standalone: true,
  imports: [],
  templateUrl: './prova.component.html',
  styleUrl: './prova.component.css'
})
export class ProvaComponent {
  @Output() mandaDatiEvento = new EventEmitter<string>();
  texto='';
  send($event: Event) {
    this.texto=(<HTMLInputElement>$event.target).value;
    this.mandaDatiEvento.emit(this.texto);
  }

}
