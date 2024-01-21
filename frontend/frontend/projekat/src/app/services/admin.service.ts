import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  private currentUsername:string;
  headers:HttpHeaders;
  route:string;
  constructor(private httpClient:HttpClient)
  {
    this.currentUsername="";
    this.headers=new HttpHeaders({
      'Content-Type':'application/json'
    });
    this.route="http://localhost:5078/"
  }

  setUsername(newUsername:string)
  {
    this.currentUsername=newUsername;
  }
  getAdmin()
  {
    
  }
}
