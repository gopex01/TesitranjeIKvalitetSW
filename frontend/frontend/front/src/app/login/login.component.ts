import { Component, OnInit } from '@angular/core';
import { LoginService } from '../services/login.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit{

  username:string;
  password:string;
  ngOnInit(): void {
    
  }
  constructor(private loginService:LoginService,private router:Router)
  {
    this.username='';
    this.password='';
  }
  login()
  {
    
    this.loginService.login(this.username,this.password);
  }
  gotoSignUp()
  {
    this.router.navigate(['SignUp']);
  }

}
