import { EventEmitter, Injectable, Output } from '@angular/core';
import { ConfirmationService } from 'primeng/api';
import { ToastService } from './toast.service';
@Injectable({
  providedIn: 'root'
})
export class ConfirmComponentService {

  constructor(private _confirm:ConfirmationService){
  }
  public confirm1(message:string,event:Event,accepCallback:()=>void){
    this._confirm.confirm({
      target: event.target as EventTarget,
      message: message,
      icon:'pi pi-exclamation-triangle',
      accept:() => { accepCallback()}
    })
  }
}
