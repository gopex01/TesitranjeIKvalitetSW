import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-user-card',
  templateUrl: './user-card.component.html',
  styleUrls: ['./user-card.component.css']
})
export class UserCardComponent implements OnInit{

  @Input()
  user:any;
  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }
  constructor()
  {
    
  }
  

}