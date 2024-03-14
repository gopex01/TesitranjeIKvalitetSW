import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AdminService } from '../services/admin.service';
import { Router } from '@angular/router';
import { UserService } from '../services/user.service';
import { BcService } from '../services/bc.service';
import { TermService } from '../services/term.service';

@Component({
  selector: 'app-admin-profile',
  templateUrl: './admin-profile.component.html',
  styleUrls: ['./admin-profile.component.css']
})
export class AdminProfileComponent implements OnInit{

  adminProfile$:Observable<any>;
  numberOfUsers:any;
  numberOfBcs:any;
  numberOfTerms:any;

constructor(private AdminService:AdminService, private router:Router, private useService:UserService, private BCService:BcService, private TermService:TermService)
  {
    this.adminProfile$=new Observable<any>();

    this.numberOfBcs=0;
    this.numberOfUsers=0;
    this.numberOfTerms=0;
  }

  
  ngOnInit(): void {
    this.adminProfile$=this.AdminService.getAdminInfo();
    this.adminProfile$.subscribe((x)=>console.log(x));

    this.numberOfBcs=this.BCService.getNumOfBcs().subscribe(x=>{
      this.numberOfBcs=x;
      console.log("Broj bc",x)});
    this.numberOfTerms=this.TermService.getNumOfTerms().subscribe(x=>{
      this.numberOfTerms=x;
      console.log("Broj termina",x)});
    this.numberOfUsers=this.useService.getNumOfUsers().subscribe(x=>{
      this.numberOfUsers=x;
      console.log("Broj usera",x)});
  }

  DodajBC()
  {
      this.router.navigate(['CreateBC']);
  }
  gotoALLBCS()
  {
    this.router.navigate(['AllBcs']);
  }
  gotoAllUsers()
  {
    this.router.navigate(['AllUsers']);
  }

  prebaciNaDelete()
  {
    this.router.navigate(['deleteBC']);
  }

}
