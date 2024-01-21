import { Component, Input, OnInit } from '@angular/core';
import { BorderCross } from '../models/bordercross.model';
import { Store } from '@ngrx/store';
import { setBCName } from '../action/bcname.action';
import { Router } from '@angular/router';

@Component({
  selector: 'app-border-cross',
  templateUrl: './border-cross.component.html',
  styleUrls: ['./border-cross.component.css']
})
export class BorderCrossComponent implements OnInit{

  @Input()
  borderCross:BorderCross|null;
  ngOnInit(): void {

    //this.store.dispatch(setBCName({BCName:this.borderCross?.name || ''}))
  }
  constructor(private store:Store,private router:Router) {
    this.borderCross=null;
  }
  info()
  {
    this.store.dispatch(setBCName({BCName:this.borderCross?.name || ''}));
    this.router.navigate(['/bcinfo'])
  }
  

}
