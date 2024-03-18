import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { map } from 'rxjs';
import * as loginAction from "../ngrx/login.action";
@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private httpClient:HttpClient,private router:Router,private store:Store)
  { 
  }
  login(username:string,password:string)
  {
    this.httpClient.get(`http://localhost:5078/UserEntityConttoller/User/login/${username}/${password}`).pipe(
      map(response=>{
        return response as any;
      })
    ).subscribe((response)=>{
      //odgovor
      if(response!=null)
      {
        console.log(response.username);
        if(response.type=='user'){
        this.router.navigate(['userProfile']);
        }
        if(response.type=='admin')
        {
          this.router.navigate(['adminProfile']);
        }
        if(response.type=='bc')
        {
          this.router.navigate(['bcProfile']);
        }
        this.store.dispatch(loginAction.setUsername({username:response.username}));
      }
      else{
        window.alert('Bad password or username.Try again!');
      }
      
    },
    (error)=>{
      console.error(console.error("Greska prilikom slanje zahteva",error));
    })
  }

  signUp( nameAndSurname:string, email:string,username:string,
    password:string, phoneNumber:string, age:number, jmbg:string)
  {
    
    let obj=
    {
      nameAndSurname:nameAndSurname,
      email:email,
      username:username,
      password:password,
      phoneNumber:phoneNumber,
      age:age,
      jmbg:jmbg
    };

    this.httpClient.post
    (`http://localhost:5078/UserEntityConttoller/User/addUser`, obj,{responseType:'text'}).subscribe({
      next:(response:any)=>{
        if(response=='Korisnik uspesno dodat')
        {
          window.alert("Sucess registration, login to continue");
        }
        else{
          window.alert("Error");
        }
      },
      error:(err:any)=>{
        window.alert("Error");
      }
    });
  





  }
}
