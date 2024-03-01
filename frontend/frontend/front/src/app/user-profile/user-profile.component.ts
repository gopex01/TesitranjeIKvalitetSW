import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit{

  user$:Observable<any>;
  constructor(private userService:UserService)
  {
    this.user$=new Observable<any>();
  }
  ngOnInit(): void {
    this.user$=this.userService.getUserInfo();
    this.user$.subscribe((x)=>console.log(x));
  }

}
