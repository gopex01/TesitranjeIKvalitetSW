import { Component, Input, OnInit } from '@angular/core';
import { TermService } from '../services/term.service';

@Component({
  selector: 'app-bc-term-card',
  templateUrl: './bc-term-card.component.html',
  styleUrls: ['./bc-term-card.component.css']
})
export class BcTermCardComponent implements OnInit{
  
  @Input()
  term:any;
  ngOnInit(): void {
    
  }
  constructor(private termService:TermService)
  {
    
  }
  updateTerm()
  {

  }

}
