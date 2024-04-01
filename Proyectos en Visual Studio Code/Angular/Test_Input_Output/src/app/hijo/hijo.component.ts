import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-hijo',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './hijo.component.html',
  styleUrl: './hijo.component.css'
})
export class HijoComponent {
  nombreHijo = "";
  haveName:boolean = false
  @Input() chiave='';
  @Output() blabla = new EventEmitter<string>()

  send(texto:string){
    this.nombreHijo=texto;
    this.haveName = true;
    this.blabla.emit(this.nombreHijo);
  }
}
