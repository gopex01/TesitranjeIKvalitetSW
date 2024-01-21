import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserService } from './user.service';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  headers:HttpHeaders;
  route:string;
  clientUsername:string="";

  constructor(private httpClinet:HttpClient,private userService:UserService) 
  { 
    this.clientUsername=this.userService.getUsername();
    this.headers=new HttpHeaders({
      'Content-Type':'application/json'
    });
    this.route="http://localhost:5078/";
  }

  getNotifications()
  {
    return this.httpClinet.get(this.route+`NotificationEntity/Notification/getNot/${this.clientUsername}`,{headers:this.headers});
  }
}
