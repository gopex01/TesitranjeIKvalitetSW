import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TermService {

  route:string;

  constructor(private httpClient:HttpClient)
  {
    this.route="http://localhost:5078/TermEntity/Term/";
  }

  createTerm(numOfPassanger:number,carBrand:string,numOfRegistration:string,chassisNumber:string,numberOfDays:number,placeOfResidence:string,dateAndTime:string,cardNumber:string)
  {
    let op;
    if(cardNumber.length==16)
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
      dateAndTime:"2024-03-02T14:43:53.179Z",
      isPaid:op,
      isCrossed:false,
      isComeBack:false,
      irregularities:'',
      accepted:false
    }
      this.httpClient.post(this.route+`addTerm/petar/Gradina`,obj).subscribe((p)=>console.log(p));    
  }
}
