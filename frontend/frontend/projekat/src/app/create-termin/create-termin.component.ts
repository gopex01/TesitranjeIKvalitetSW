import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { BorderCross } from '../models/bordercross.model';
import { BordercrossService } from '../services/bordercross.service';

@Component({
  selector: 'app-create-termin',
  templateUrl: './create-termin.component.html',
  styleUrls: ['./create-termin.component.css']
})
export class CreateTerminComponent implements OnInit{

  numberOfPassangers:string="";
  carBrand:string="";
  chassisNumber:string="";
  numberOfDays:string="";
  placeOfResidence:string="";
  cardNumber:string="";
  arrBC$:Observable<any>;
  selectedBC:BorderCross|null;
  ngOnInit(): void {
    this.arrBC$=this.bcService.getAllBC();
    this.arrBC$.subscribe();
  }
  constructor(private bcService:BordercrossService)
  {
    this.arrBC$=new Observable<any>();
    this.selectedBC=null;
  }
  onBorderCrossSelected()
  {

  }
  createTerm()
  {
    if(this.cardNumber.length==16)
    {
        
    }
  }
  

}
