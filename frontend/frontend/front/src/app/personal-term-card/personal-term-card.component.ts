import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-personal-term-card',
  templateUrl: './personal-term-card.component.html',
  styleUrls: ['./personal-term-card.component.css']
})
export class PersonalTermCardComponent implements OnInit{

  @Input()
  term:any;
  ngOnInit(): void {
   
  }

}
