import { HttpClient } from "@angular/common/http";
import { Component, Input, OnInit } from "@angular/core";
import { TermService } from "../services/term.service";

@Component({
  selector: "app-personal-term-card",
  templateUrl: "./personal-term-card.component.html",
  styleUrls: ["./personal-term-card.component.css"],
})
export class PersonalTermCardComponent implements OnInit {
  @Input()
  term: any;
  ngOnInit(): void {}

  constructor(private TermService: TermService) {}

  deleteTerm(): void {
    this.TermService.deleteTerm(this.term.id);
  }
}
