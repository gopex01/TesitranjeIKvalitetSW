import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { BcService } from '../services/bc.service';

@Component({
  selector: 'app-bc-profile',
  templateUrl: './bc-profile.component.html',
  styleUrls: ['./bc-profile.component.css']
})
export class BcProfileComponent implements OnInit {

  bcProfile$:Observable<any>;

  constructor(private BCServer:BcService)
  {
    this.bcProfile$=new Observable<any>();
  }



  ngOnInit(): void {
    this.bcProfile$=this.BCServer.getBCInfo();
    this.bcProfile$.subscribe((x)=>console.log(x));
  }


}
