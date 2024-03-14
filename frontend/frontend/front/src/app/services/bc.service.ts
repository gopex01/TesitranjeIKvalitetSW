import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { Store } from "@ngrx/store";
import { switchMap, take, tap } from "rxjs";
import { selectUsername } from "../ngrx/login.selector";

@Injectable({
  providedIn: "root",
})
export class BcService {
  route: string;

  constructor(
    private httpClient: HttpClient,
    private router: Router,
    private store: Store
  ) {
    this.route = "http://localhost:5078/BorderCrossEntity/BorderCross/";
  }

  getBCInfo() {
    return this.store
      .select(selectUsername)
      .pipe(
        switchMap((username) =>
          this.httpClient.get(this.route + `getOneBC/${username}`)
        )
      );
  }

  getAllBCs() {
    return this.httpClient.get(this.route + `getALLBCS`);
  }

  createBC(
    name: string,
    username: string,
    password: string,
    location: string,
    country: string,
    type: string,
    workHour: string,
    transportConnections: string,
    capacity: string,
    email: string,
    phoneNumber: string,
    description: string
  ) {
    let obj = {
      name: name,
      username: username,
      password: password,
      location: location,
      country: country,
      type: type,
      workHour: workHour,
      transportConnections: transportConnections,
      capacity: capacity,
      email: email,
      phoneNumber: phoneNumber,
      description: description,
    };

    console.log(obj);

    this.httpClient.post(this.route + `addBC`, obj).subscribe(x=>{
      console.log('resp',x);
    });
  }

  deleteBC(name: string) {
  this.httpClient.delete(this.route+`deleteBC/${name}`).subscribe();


  }

  getNumOfBcs()
  {
   return  this.httpClient.get(this.route+`getNumOfBC`);
  }
}
