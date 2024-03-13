import { Component, OnInit } from '@angular/core';
import { LoginService } from '../services/login.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit{

  nameAndSurname:string;
  email:string;
  username:string;
  password:string;
  phoneNumber:string;
  age:number;
  jmbg:string;
  constructor(private loginService:LoginService)
  {
    this.nameAndSurname="";
    this.email="";
    this.username="";
    this.password="";
    this.phoneNumber="";
    this.age=0;
    this.jmbg="";
  }
  ngOnInit(): void {
  }
  signUp()
  {

  }

}
