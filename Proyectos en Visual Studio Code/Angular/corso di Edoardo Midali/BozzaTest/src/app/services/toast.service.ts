import { Injectable } from '@angular/core';
import { MessageService } from 'primeng/api';

@Injectable({
  providedIn: 'root'
})
export class ToastService {

  constructor(private _messageService : MessageService){
  }
  
  showSuccess(message:string){
      this._messageService.add(
        {
          severity:'success',
          summary:'Success',
          detail:message
        })
    }
  showInfo(message:string){
    debugger
    this._messageService.add(
      {
        severity:'success',
        summary:'Success',
        detail:message
      });
  }
  showWarn(message:string){
    this._messageService.add(
      {
        severity:'success',
        summary:'Success',
        detail:message
      });
  }
  showError(message:string){
    this._messageService.add(
      {
        severity:'success',
        summary:'Success',
        detail:message
      });
  }
}
