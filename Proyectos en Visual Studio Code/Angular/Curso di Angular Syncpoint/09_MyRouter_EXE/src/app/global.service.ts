import { Injectable } from '@angular/core';
import { Logged } from '../classi/logged';

@Injectable({
  providedIn: 'root'
})
export class GlobalService {

  logged:Logged = {log:"", id:"",name:""};
  constructor() { }

  
}
