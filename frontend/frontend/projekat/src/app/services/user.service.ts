import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../models/user.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
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
   getUser()
  {
    
    return this.httpClient.get(this.route+`UserEntityConttoller/User/getOneUser/${this.currentUsername}`,{headers:this.headers});
  }
  getUsername()
  {
    return this.currentUsername;
  }
}
