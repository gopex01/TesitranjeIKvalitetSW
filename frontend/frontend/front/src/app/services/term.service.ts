import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { selectUsername } from '../ngrx/login.selector';
import { switchMap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TermService {

  route:string;

  constructor(private httpClient:HttpClient,private store:Store)
  {
    this.route="http://localhost:5078/TermEntity/Term/";
  }

  createTerm(numOfPassanger:number,carBrand:string,numOfRegistration:string,chassisNumber:string,numberOfDays:number,placeOfResidence:string,dateAndTime:string,cardNumber:string)
  {
    let op;
    if(cardNumber.length==8)
    {
      op=true;
    }
    else{
      op=false;
    }
    let obj={
      numOfPassanger:numOfPassanger,
      carBrand:carBrand,
      numOfRegistrationPlates:numOfRegistration,
      chassisNumber:chassisNumber,
      numberOfDays:numberOfDays,
      placeOfResidence:placeOfResidence,
      dateAndTime: dateAndTime,
      isPaid:op,
      isCrossed:false,
      isComeBack:false,
      irregularities:'',
      accepted:false
    }//dodaj ovamo
      this.httpClient.post(this.route+`addTerm/petar/Gradina`,obj,{responseType:'text'}).subscribe({
        next:(response:any)=>{
          window.alert("Success created term")
        },
        error:(err:any)=>{
          window.alert("Error")
        }
      });    
  }
  getPersonalTerms()
  {
    return this.store.select(selectUsername).pipe(
      switchMap(username=>
        this.httpClient.get(this.route+`getPersonalTerms/${username}`))
    )
  }
  getTerms()
  {
    return this.store.select(selectUsername).pipe(
      switchMap(username=>
        this.httpClient.get(this.route+`getTerms/${username}`))
    )
  }
  updateTerm(idTerm:any,isCrossed:any,isComeBack:any,irregularities:any)
  {
    return this.httpClient.patch(this.route+`updateTerm/${idTerm}/${isCrossed}/${isComeBack}/${irregularities}`,{},{responseType:'text'}).subscribe({
      next:(response:any)=>{
        if(response=="Success")
        {
          window.alert("Success updated term!");
        }
        else{
          window.alert("Error");
        }
      }
    });
  }

  deleteTerm(idTerm:number)
  {
    return this.httpClient.delete(this.route+`deleteTerm/${idTerm}`,{responseType:'text'}).subscribe({
      next:(response:any)=>{
        if(response=="Success")
        {
          window.alert("Success deleted term");
        }
        else{
          window.alert("Error");
        }
      },
      error:(err:any)=>{
        window.alert
        ("Error");
      }
    });
    
  }

  getNumOfTerms()
  {
    return this.httpClient.get(this.route+`getNumOfTerms`);
  }
}
