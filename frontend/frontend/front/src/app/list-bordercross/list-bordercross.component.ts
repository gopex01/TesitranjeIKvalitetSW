import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { BcService } from '../services/bc.service';

@Component({
  selector: 'app-list-bordercross',
  templateUrl: './list-bordercross.component.html',
  styleUrls: ['./list-bordercross.component.css']
})
export class ListBordercrossComponent implements OnInit {
  ngOnInit(): void {
      this.arrayBC$= this.BCService.getAllBCs();
      this.arrayBC$.subscribe(x=>console.log(x));
  }

  arrayBC$:Observable<any>;

  constructor( private BCService:BcService)
  {
    this.arrayBC$=new Observable<any>();
  }


}
