import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class NetworkService {
  constructor(private httpClient:HttpClient) { }

  httpGetNetwork(url:string){
    return this.httpClient.get<any>(url)
    
  }
}
