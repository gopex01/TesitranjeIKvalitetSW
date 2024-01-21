import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { TermService } from '../services/term.service';

@Component({
  selector: 'app-list-personal-term',
  templateUrl: './list-personal-term.component.html',
  styleUrls: ['./list-personal-term.component.css']
})
export class ListPersonalTermComponent implements OnInit{

  arrTerm$:Observable<any>;
  ngOnInit(): void {
    this.arrTerm$=this.termService.getPersonalTerms();
    this.arrTerm$.subscribe((x)=>console.log(x));
  }
  constructor(private termService:TermService)
  {
    this.arrTerm$=new Observable<any>();
  }
  

}
