import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Logged } from '../../classi/logged';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private httpClient:HttpClient) { }

  httpPostLogin(url:string,datiStringa:string){
    return this.httpClient.post<Logged>(url, datiStringa)
    
  }
}
