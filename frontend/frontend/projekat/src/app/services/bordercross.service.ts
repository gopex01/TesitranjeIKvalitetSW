import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BordercrossService {

  private currentUsername:string;
  headers:HttpHeaders;
  route:string;
  constructor(private httpClient:HttpClient) 
  {
    this.currentUsername="";
    this.headers=new HttpHeaders({
      'Content-Type':'application/json'
    });
    this.route="http://localhost:5078/";
  }
  setUsername(newUsername:string)
  {
    this.currentUsername=newUsername;
  }
  getBCUser()
  {
    return this.httpClient.get(this.route+`BorderCrossEntity/BorderCross/getOneBC/${this.currentUsername}`,{headers:this.headers});
  }
  getBC(name:string|undefined)
  {
    return this.httpClient.get(this.route+`BorderCrossEntity/BorderCross/getBorderCross/${name}`,{headers:this.headers});
  }
  getAllBC()
  {
    return this.httpClient.get(this.route+`BorderCrossEntity/BorderCross/getALLBCS`,{headers:this.headers});
  }
  getUsername()
  {
    return this.currentUsername;
  }
}
