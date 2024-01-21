import { Component, Input, OnInit } from '@angular/core';
import { Term } from '../models/term.model';

@Component({
  selector: 'app-term',
  templateUrl: './term.component.html',
  styleUrls: ['./term.component.css']
})
export class TermComponent implements OnInit{
  @Input()
  term:Term|null;
  isCrossed:string;
  isComeBack:string;
  irregulations:string;
  ngOnInit(): void {
  }
  constructor()
  {
    this.term=null;
    this.term=null;
    this.isCrossed="";
    this.isComeBack="";
    this.irregulations="";
  }
  change()
  {
    //this.bcService.checkTerm(this.term?.Id!,this.isCrossed,this.isComeBack,this.irregulations);
  }

}
