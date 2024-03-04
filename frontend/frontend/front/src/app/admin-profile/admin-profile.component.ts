import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AdminService } from '../services/admin.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin-profile',
  templateUrl: './admin-profile.component.html',
  styleUrls: ['./admin-profile.component.css']
})
export class AdminProfileComponent implements OnInit{

  adminProfile$:Observable<any>;

constructor(private AdminService:AdminService, private router:Router)
  {
    this.adminProfile$=new Observable<any>();
  }

  
  ngOnInit(): void {
    this.adminProfile$=this.AdminService.getAdminInfo();
    this.adminProfile$.subscribe((x)=>console.log(x));
  }

  DodajBC()
  {
    console.log("bastami")
      this.router.navigate(['CreateBC']);
  }

}
