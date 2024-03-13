import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { TermService } from '../services/term.service';

@Component({
  selector: 'app-list-bc-term',
  templateUrl: './list-bc-term.component.html',
  styleUrls: ['./list-bc-term.component.css']
})
export class ListBcTermComponent implements OnInit{

  arrayTerm$:Observable<any>;
 
  constructor(private termService:TermService)
  {
    this.arrayTerm$=new Observable<any>();
   
  }
  ngOnInit(): void {
    this.arrayTerm$=this.termService.getTerms();
    this.arrayTerm$.subscribe(x=>{
      console.log(x);
    });
}
}
