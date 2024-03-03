import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { UserService } from '../services/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit{

  user$:Observable<any>;
  constructor(private userService:UserService,private router:Router)
  {
    this.user$=new Observable<any>();
  }
  ngOnInit(): void {
    this.user$=this.userService.getUserInfo();
    this.user$.subscribe((x)=>console.log(x));
  }
  gotoCreateTerm()
  {
    console.log('gotofja');
    this.router.navigate(['createTerm']);
  }

  returnAllBcs()
  {
    this.router.navigate(['AllBcs']);
  }
  gotoSettings()
  {
    this.router.navigate(['Settings']);
  }

}
