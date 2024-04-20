import { Component } from '@angular/core';
import { ButtonModule } from 'primeng/button';
import { ToastService } from '../services/toast.service';
import { ConfirmComponentService } from '../services/confirm-component.service';
@Component({
  selector: 'app-prova',
  standalone: true,
  imports: [ButtonModule],
  templateUrl: './prova.component.html',
  styleUrl: './prova.component.scss'
})
export class ProvaComponent {

  constructor(private _serviceToast: ToastService,private _confirm:ConfirmComponentService) {
  }

mostrarToast(event:Event){
  this._serviceToast.showInfo("has clicado en el button");
}

confirmation(event:Event) {
  this._confirm.confirm1("estas seguro?",event,()=>{this.mostrarToast(event)})

}
}
