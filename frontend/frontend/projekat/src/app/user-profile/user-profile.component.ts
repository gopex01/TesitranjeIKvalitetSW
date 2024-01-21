import { Component, Input, OnInit } from '@angular/core';
import { User } from '../models/user.model';
import { UserService } from '../services/user.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit{

  user$:Observable<any>=new Observable<any>();
  constructor(private userService:UserService)
  {
    
  }
  ngOnInit(): void {
   this.getData();
  }
  async getData()
  {
    this.user$=await this.userService.getUser();
  }


}
