import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http'
import { Router } from '@angular/router';
import { UserService } from './user.service';
import { BordercrossService } from './bordercross.service';
import { AdminService } from './admin.service';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  headers:HttpHeaders;
  route:string;
  constructor(private httpClient:HttpClient,
    private userService:UserService,
    private bcService:BordercrossService,
    private adminService:AdminService,
    private router:Router)
  {
    this.headers=new HttpHeaders({
      'Content-Type':'application/json'
    });
    this.route="http://localhost:5078/";
  }
  login(username:string,password:string)
  {
    //http://localhost:5078/App/App/login/string/string
    this.httpClient.post(this.route+`App/App/login/${username}/${password}`,{},{headers:this.headers}).subscribe(
      (resp:any)=>{
        console.log(resp);
        if(resp!=null)
        {
          if(resp.type=='user')
          {
            this.userService.setUsername(resp.username);
            this.router.navigate(['/userprofile'])
          }
          else{
            if(resp.type=='bc')
            {
              this.bcService.setUsername(resp.username);
              this.router.navigate(['/bcprofile']);
            }
            else{
              this.adminService.setUsername(resp.username);
              this.router.navigate(['/adminprofile'])
            }
          }
        }

      },
      (error)=>{
        console.log(error);
      }
    );
  }
}
