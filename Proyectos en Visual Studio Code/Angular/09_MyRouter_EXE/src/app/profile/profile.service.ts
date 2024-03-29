import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class ProfileService {

  constructor(private httpClient:HttpClient) { }

  httpGetProfile(url:string){
    return this.httpClient.get<any>(url)
    
  }

  httpAddNote(url:string,data:any){
    console.log(url+data);
    return this.httpClient.put<any>(url,data);
  }

  httpRemoveNote(url:string,data:any){
    return this.httpClient.delete<any>(url,{ body: { id_note: data } });
  }
}
