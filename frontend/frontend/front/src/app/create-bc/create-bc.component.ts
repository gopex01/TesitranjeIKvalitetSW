import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { BcService } from "../services/bc.service";

@Component({
  selector: "app-create-bc",
  templateUrl: "./create-bc.component.html",
  styleUrls: ["./create-bc.component.css"],
})
export class CreateBCComponent implements OnInit {
  name: string;
  username: string;
  password: string;
  location: string;
  country: string;
  type: string;
  workHour: string;
  transportConnections: string;
  capacity: string;
  email: string;
  phoneNumber: string;
  description: string;

  constructor(private borderCrossService: BcService) {
    // Inicijalizacija atributa
    this.name = "";
    this.username = "";
    this.password = "";
    this.location = "";
    this.country = "";
    this.type = "";
    this.workHour = "";
    this.transportConnections = "";
    this.capacity = "";
    this.email = "";
    this.phoneNumber = "";
    this.description = "";
  }
  ngOnInit(): void {}

  dodajBC() {
    this.borderCrossService.createBC(this.name, this.username, this.password, this.location,
      this.country, this.type, this.workHour, this.transportConnections, this.capacity, this.email,
      this.phoneNumber, this.description);

  }
}
