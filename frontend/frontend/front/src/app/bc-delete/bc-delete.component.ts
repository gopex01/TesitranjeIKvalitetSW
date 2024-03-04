import { Input } from '@angular/core';
import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { BcService } from '../services/bc.service';

@Component({
  selector: 'app-bc-delete',
  templateUrl: './bc-delete.component.html',
  styleUrls: ['./bc-delete.component.css']
})
export class BcDeleteComponent implements OnInit {


  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }
  
  constructor(private BCService:BcService)
  {

  }

  @Input()
  bc:any;

  obrisiBC()
  {
    this.BCService.deleteBC(this.bc.name);
    

  }
}
