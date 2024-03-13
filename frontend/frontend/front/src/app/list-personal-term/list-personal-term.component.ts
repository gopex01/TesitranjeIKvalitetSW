import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { TermService } from '../services/term.service';

@Component({
  selector: 'app-list-personal-term',
  templateUrl: './list-personal-term.component.html',
  styleUrls: ['./list-personal-term.component.css']
})
export class ListPersonalTermComponent implements OnInit{

  arrayTerm$:Observable<any>;
 
  constructor(private termService:TermService)
  {
    this.arrayTerm$=new Observable<any>();
   
  }
  ngOnInit(): void {
    this.arrayTerm$=this.termService.getPersonalTerms();
    this.arrayTerm$.subscribe(x=>{
      console.log(x);
    });
    
  }

}
