import { Component, OnInit } from '@angular/core';
import { TermService } from '../services/term.service';

@Component({
  selector: 'app-create-term',
  templateUrl: './create-term.component.html',
  styleUrls: ['./create-term.component.css']
})
export class CreateTermComponent implements OnInit{
  

  numOfPassanger:number;
  carBrand:string;
  numOfRegistration:string;
  chassisNumber:string;
  numberOfDays:number;
  placeOfResidence:string;
  dateAndTime:string;
  cardNumber:string;
  ngOnInit(): void {
  }
  constructor(private termService:TermService)
  {
    this.numOfPassanger=0;
    this.carBrand="";
    this.numOfRegistration="";
    this.chassisNumber="";
    this.numberOfDays=0;
    this.placeOfResidence="";
    this.dateAndTime="";
    this.cardNumber="";
  }
  createTerm()
  {
    this.termService.createTerm(this.numOfPassanger,this.carBrand,this.numOfRegistration,this.chassisNumber,this.numberOfDays,this.placeOfResidence,this.dateAndTime,this.cardNumber);
  }

}
