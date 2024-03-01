import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
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
}
