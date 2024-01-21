import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Admin } from '../models/admin.model';

@Component({
  selector: 'app-adminprofile',
  templateUrl: './adminprofile.component.html',
  styleUrls: ['./adminprofile.component.css']
})
export class AdminprofileComponent implements OnInit{

  admin$:Observable<Admin>;
  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }
  constructor()
  {
    this.admin$=new Observable<Admin>();
  }

}
