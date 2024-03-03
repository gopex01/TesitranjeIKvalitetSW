import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-bordercross',
  templateUrl: './bordercross.component.html',
  styleUrls: ['./bordercross.component.css']
})
export class BordercrossComponent  implements OnInit   {
  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }
  
  constructor()
  {

  }

  @Input()
  bc:any;

}
