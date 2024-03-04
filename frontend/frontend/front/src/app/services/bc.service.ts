import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { switchMap } from 'rxjs';
import { selectUsername } from '../ngrx/login.selector';

@Injectable({
  providedIn: 'root'
})
export class BcService {

  route:string;


  constructor(private httpClient:HttpClient,
              private router:Router,private store:Store) {
                this.route="http://localhost:5078/BorderCrossEntity/BorderCross/";

               }

getBCInfo()
{
  return this.store.select(selectUsername).pipe(
    switchMap(username=>
      this.httpClient.get(this.route+`getOneBC/${username}`))
  )
}

getAllBCs()
{
  return this.httpClient.get(this.route+`getALLBCS`);
  
}

createBC(Name: string,
  Username: string,
  Password: string,
  Location: string,
  Country: string,
  Type: string,
  WorkHour: string,
  TransportConnections: string,
  Capacity: number,
  Email: string,
  PhoneNumber: string,
  Description: string)
{
  let obj=
  {
  name:Name,
  username:Username,
  password:Password,
  location:Location,
  country:Country,
  type:Type,
  workHour:WorkHour,
  transportConnections: TransportConnections,
  capacity:Capacity,
  email:Email,
  phoneNumber:PhoneNumber,
  description:Description
  };

  console.log(obj);

  
  this.httpClient.post(this.route+`addBC`, obj).subscribe();

}
}
