import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { BcService } from '../services/bc.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-bc-profile',
  templateUrl: './bc-profile.component.html',
  styleUrls: ['./bc-profile.component.css']
})
export class BcProfileComponent implements OnInit {

  bcProfile$:Observable<any>;

  constructor(private BCServer:BcService,private router:Router)
  {
    this.bcProfile$=new Observable<any>();
  }



  ngOnInit(): void {
    this.bcProfile$=this.BCServer.getBCInfo();
    this.bcProfile$.subscribe((x)=>console.log(x));
  }
  gotoAllTerms()
  {
    this.router.navigate(['/BCTerm']);
  }


}
