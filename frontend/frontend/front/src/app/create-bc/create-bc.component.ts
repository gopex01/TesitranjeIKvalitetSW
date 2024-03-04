import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { BcService } from "../services/bc.service";

@Component({
  selector: "app-create-bc",
  templateUrl: "./create-bc.component.html",
  styleUrls: ["./create-bc.component.css"],
})
export class CreateBCComponent implements OnInit {
  Name: string;
  Username: string;
  Password: string;
  Location: string;
  Country: string;
  Type: string;
  WorkHour: string;
  TransportConnections: string;
  Capacity: number;
  Email: string;
  PhoneNumber: string;
  Description: string;

  constructor(private borderCrossService: BcService) {
    // Inicijalizacija atributa
    this.Name = "";
    this.Username = "";
    this.Password = "";
    this.Location = "";
    this.Country = "";
    this.Type = "";
    this.WorkHour = "";
    this.TransportConnections = "";
    this.Capacity = 0;
    this.Email = "";
    this.PhoneNumber = "";
    this.Description = "";
  }
  ngOnInit(): void {}

  dodajBC() {
    this.borderCrossService.createBC(this.Name, this.Username, this.Password, this.Location,
      this.Country, this.Type, this.WorkHour, this.TransportConnections, this.Capacity, this.Email,
      this.PhoneNumber, this.Description);

  }
}
