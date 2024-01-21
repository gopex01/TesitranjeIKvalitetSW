import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { BorderCross } from '../models/bordercross.model';
import { BordercrossService } from '../services/bordercross.service';

@Component({
  selector: 'app-list-border-cross',
  templateUrl: './list-border-cross.component.html',
  styleUrls: ['./list-border-cross.component.css']
})
export class ListBorderCrossComponent implements OnInit{

  arrBc$:Observable<any>;
  ngOnInit(): void {
    this.arrBc$=this.bcService.getAllBC();
    this.arrBc$.subscribe((x)=>console.log(x));
  }
  constructor(private bcService:BordercrossService)
  {
    this.arrBc$=new Observable<BorderCross[]>();
  }


  
}
