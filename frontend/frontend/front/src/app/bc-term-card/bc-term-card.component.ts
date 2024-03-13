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

   isCrossed: boolean;
   isComeBack: boolean;
   Irregularities:string;


  ngOnInit(): void {
    
  }
  constructor(private termService:TermService)
  {
    this.isCrossed=false;
    this.isComeBack=false;
    this.Irregularities='';

  }

  printValues() :void
  {
    console.log(this.isComeBack, this.isCrossed,this.Irregularities);
    console.log(this.term.id);
  };



  updateTerm() 
  {
    console.log("proba");
    
    this.termService.updateTerm(this.term.id, this.isCrossed, this.isComeBack, this.Irregularities);
 };

}
