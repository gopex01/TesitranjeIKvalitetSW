import { Component, OnInit } from '@angular/core';
import { NgModule } from '@angular/core';
import { LoginService } from '../services/login.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit{

  vrednostUsername:string;
  vrednostPassword:string;
  vrednostName:string;
  vrednostEmail:string;
  vrednostUsernameReg:string;
  vrednostPasswordReg:string;
  vrednostPhoneNumber:string;
  vrednostDate:string;
  vrednostJMBG:string;
  ngOnInit(): void {
  
  }
  constructor(private loginService:LoginService)
  {
    this.vrednostUsername="";
    this.vrednostPassword="";
    this.vrednostName="";
    this.vrednostEmail="";
    this.vrednostUsernameReg="";
    this.vrednostPasswordReg="";
    this.vrednostPhoneNumber="";
    this.vrednostDate="";
    this.vrednostJMBG="";
  }
  login()
  {
    this.loginService.login(this.vrednostUsername,this.vrednostPassword);
  }
  register()
  {

  }

}
