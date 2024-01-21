import { Component, OnInit } from '@angular/core';
import { BorderCross } from '../models/bordercross.model';
import { Store } from '@ngrx/store';
import { selectBCName } from '../selector/bcname.selector';
import { BordercrossService } from '../services/bordercross.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-border-cross-info',
  templateUrl: './border-cross-info.component.html',
  styleUrls: ['./border-cross-info.component.css']
})
export class BorderCrossInfoComponent implements OnInit{

  borderCross$:Observable<any>;
  ngOnInit(): void {
    this.store.select(selectBCName).subscribe((resp)=>{
        //pozovem service koji vrne bc
        this.borderCross$=this.bcService.getBC(resp);
        this.borderCross$.subscribe((x)=>console.log(x));
    })
  }
  constructor(private store:Store,private bcService:BordercrossService)
  {
    this.borderCross$=new Observable<BorderCross>;
  }

}
