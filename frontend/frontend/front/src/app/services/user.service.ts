import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Store, select } from '@ngrx/store';
import { selectUsername } from '../ngrx/login.selector';
import { switchMap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  route:string;
  constructor(private httpClient:HttpClient,private router:Router,private store:Store)
  { 
    this.route="http://localhost:5078/UserEntityConttoller/User/";
  }
  getUserInfo()
  {
   
    return this.store.select(selectUsername).pipe(
      switchMap(username=>
        this.httpClient.get(this.route+`getOneUser/${username}`))
    )
  }
  changeName(newName:string)
  {
    console.log('pozvao sam name');
    this.store.select(selectUsername).pipe(
      switchMap(username=>
      this.httpClient.patch(this.route+`updateName/${newName}/${username}`,{})
      )
    ).subscribe();
  }
  changeEmail(newEmail:string)
  {
    this.store.select(selectUsername).pipe(
      switchMap(username=>
        this.httpClient.patch(this.route+`updateEmail/${newEmail}/${username}`,{})
      )
    ).subscribe();
    
  }
  changePhone(newPhone:string)
  {
    this.store.select(selectUsername).pipe(
      switchMap(username=>
        this.httpClient.patch(this.route+`updatePhoneNumber/${newPhone}/${username}`,{})
        )
    ).subscribe()
  }
  changeUsername(newUsername:string)
  {
    console.log('pozvao sam');
    this.store.select(selectUsername).pipe(
      switchMap(username=>
        this.httpClient.patch(this.route+`updateUsername/${newUsername}/${username}`,{})
        )
    ).subscribe()
  }
  deactivateAccount(newPassword:string)
  {
    this.store.select(selectUsername).pipe(
      switchMap(username=>
        this.httpClient.delete(this.route+`deactivateAccount/${username}/${newPassword}`))
    ).subscribe()
  }
  getAllUsers()
  {
    return this.httpClient.get(this.route+'getAllUsers');
  }
}
