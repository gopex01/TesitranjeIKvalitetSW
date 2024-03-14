import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-list-user-card',
  templateUrl: './list-user-card.component.html',
  styleUrls: ['./list-user-card.component.css']
})
export class ListUserCardComponent implements OnInit{
  
  arrUsers$:Observable<any>;
  constructor(private userService:UserService)
  {
    this.arrUsers$=new Observable<any>();
  }
  ngOnInit(): void {
    this.arrUsers$=this.userService.getAllUsers();
    this.arrUsers$.subscribe(x=>console.log(x));
  }

}
