import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { BcService } from '../services/bc.service';

@Component({
  selector: 'app-list-bc-delete',
  templateUrl: './list-bc-delete.component.html',
  styleUrls: ['./list-bc-delete.component.css']
})
export class ListBcDeleteComponent {

  ngOnInit(): void {
    this.arrayBC$= this.BCService.getAllBCs();
    this.arrayBC$.subscribe(x=>console.log(x));
}

arrayBC$:Observable<any>;

constructor( private BCService:BcService)
{
  this.arrayBC$=new Observable<any>();
}


}
