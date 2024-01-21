import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserService } from './user.service';
import { BordercrossService } from './bordercross.service';

@Injectable({
  providedIn: 'root'
})
export class TermService {

  headers:HttpHeaders;
  route:string;
  clientUsername:string="";
  bcUsername:string="";
  constructor(private httpClient:HttpClient,private userService:UserService,private bcService:BordercrossService) 
  {
      this.clientUsername=this.userService.getUsername();
      this.headers=new HttpHeaders({
        'Content-Type':'application/json'
      });
      this.route="http://localhost:5078/";
      this.bcUsername=this.bcService.getUsername();
    
  }

  createTermin()
  {
    //logika da se napravi termin
  }
  getPersonalTerms()
  {
    this.clientUsername=this.userService.getUsername();
    return this.httpClient.get(this.route+`TermEntity/Term/getPersonalTerms/${this.clientUsername}`,{headers:this.headers});
  }
  getTermsOfBC()
  {
    this.bcUsername=this.bcService.getUsername();
    return this.httpClient.get(this.route+`TermEntity/Term/getTerms/${this.bcUsername}`,{headers:this.headers
    });
  }
}
