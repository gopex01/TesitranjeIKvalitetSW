import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { BorderCross } from '../models/bordercross.model';
import { BordercrossService } from '../services/bordercross.service';

@Component({
  selector: 'app-bcprofile',
  templateUrl: './bcprofile.component.html',
  styleUrls: ['./bcprofile.component.css']
})
export class BcprofileComponent implements OnInit{

  bcUser$:Observable<any>;
  ngOnInit(): void {
    this.getData();
  }
  constructor(private bcService:BordercrossService)
  {
    this.bcUser$=new Observable<any>();
  }
  async getData()
  {
    this.bcUser$=await this.bcService.getBCUser();
  }

}
