import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { TermService } from '../services/term.service';

@Component({
  selector: 'app-list-term',
  templateUrl: './list-term.component.html',
  styleUrls: ['./list-term.component.css']
})
export class ListTermComponent implements OnInit{

  arrTerm$:Observable<any>;
  ngOnInit(): void {
    this.arrTerm$=this.termService.getTermsOfBC();
    this.arrTerm$.subscribe((x)=>console.log(x));
  }
  constructor(private termService:TermService)
  {
    this.arrTerm$=new Observable<any>();
  }

}
