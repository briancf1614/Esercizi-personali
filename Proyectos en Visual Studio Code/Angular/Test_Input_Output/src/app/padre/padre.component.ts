import { Component, EventEmitter, Output } from '@angular/core';
import { HijoComponent } from '../hijo/hijo.component';

@Component({
  selector: 'app-padre',
  standalone: true,
  imports: [HijoComponent],
  templateUrl: './padre.component.html',
  styleUrl: './padre.component.css'
})
export class PadreComponent {

  @Output() dato = new EventEmitter<{name:string,key:string}>();
            
  onRicevo(event: string) {
    this.username = event;
    const data = {name:event,key:this.chiave}
    this.dato.emit(data);
  }
  chiave: string ='123456789';
  username:string = '';

}
