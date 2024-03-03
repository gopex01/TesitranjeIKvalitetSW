import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { UserService } from '../services/user.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-user-settings',
  templateUrl: './user-settings.component.html',
  styleUrls: ['./user-settings.component.css']
})
export class UserSettingsComponent implements OnInit{


  ngOnInit(): void {
    this.user$=this.userService.getUserInfo();
    this.user$.subscribe((x)=>{
      this.name=x.nameAndSurname;
      this.username=x.username;
      this.email=x.email;
      this.phone=x.phoneNumber;
      console.log(x);
    });
  }
  constructor(private store:Store,private userService:UserService)
  {
    this.newName="";
    this.newEmail="";
    this.newPhone="";
    this.newUsername="";
    this.isVisibleIEmail=false;
    this.isVisibleIName=false;
    this.isVisibleIPhone=false;
    this.isVisibleIUsername=false;
    this.isVisibleDeactivateButton=false;
    this.isVisibleDeactivateInput=false;
    this.name="";
    this.username="";
    this.email="";
    this.phone="";
    this.passwordValue="";
    this.user$=new Observable<any>();
  }

  isVisibleIName:Boolean;
  isVisibleIEmail:Boolean;
  isVisibleIUsername:Boolean;
  isVisibleIPhone:Boolean;
  isVisibleDeactivateInput:Boolean;
  isVisibleDeactivateButton:Boolean;
  newName:string;
  newPhone:string;
  newUsername:string;
  newEmail:string;
  email:string|undefined;
  name:string|undefined;
  username:string;
  phone:string|undefined;
  passwordValue:string;
  user$:Observable<any>;

  changeVisibiltyIName()
  {
    if(this.isVisibleIName===true){
      this.isVisibleIName=false;
    }
    else{
      this.isVisibleIName=true;
    }
  }
  changeVisibiltyIEmail()
  {
    if(this.isVisibleIEmail){
    this.isVisibleIEmail=false;
    }
    else{
      this.isVisibleIEmail=true;
    }
  }
  changeVisibiltyIPhone()
  {
    if(this.isVisibleIPhone)
    {
      this.isVisibleIPhone=false;
    }
    else{
      this.isVisibleIPhone=true;
    }
  }
  changeVisibiltyIUsername()
  {
    if(this.isVisibleIUsername){
      this.isVisibleIUsername=false;
    }
    this.isVisibleIUsername=true;
  }
  changeVisibiltyDeactivate()
  {
    if(this.isVisibleDeactivateButton)
    {
      this.isVisibleDeactivateButton=false;
    }
    else{
      this.isVisibleDeactivateButton=true;
    }
    if(this.isVisibleDeactivateInput)
    {
      this.isVisibleDeactivateInput=false;
    }
    else{
      this.isVisibleDeactivateInput=true;
    }
  }
  changeName()
  {
    this.userService.changeName(this.newName);
    this.changeVisibiltyIName();
    this.name=this.newName;
  }
  changeEmail()
  {
    this.changeVisibiltyIEmail();
    this.userService.changeEmail(this.newEmail);
    this.email=this.newEmail;
  }
  changePhone()
  {
    console.log(this.newPhone);
    this.userService.changePhone(this.newPhone);
    this.phone=this.newPhone;
  }
  changeUsername()
  {
    this.changeVisibiltyIUsername();
    this.userService.changeUsername(this.newUsername);
    this.username=this.newUsername;
  }
  deactivate()
  {
    this.userService.deactivateAccount(this.passwordValue);
  }
}
