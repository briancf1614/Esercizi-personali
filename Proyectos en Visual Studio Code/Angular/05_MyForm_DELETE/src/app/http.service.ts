import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  // Inietta istanza di HttpClient
  constructor(private http: HttpClient) { }
 
  // Richiesta HTTP POST
  postData(url: string, data: any) {
      // Restituisce Observable contenente la Response
      return this.http.post(url, data);
  }

  // Richiesta HTTP GET
  getData(url: string) {
      // Restituisce Observable contenente la Response
      return this.http.get(url);
  }
}
