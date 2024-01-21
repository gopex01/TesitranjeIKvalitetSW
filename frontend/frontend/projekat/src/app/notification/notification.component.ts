import { Component, Input, OnInit } from '@angular/core';
import { Notification } from '../models/notification.model';

@Component({
  selector: 'app-notification',
  templateUrl: './notification.component.html',
  styleUrls: ['./notification.component.css']
})
export class NotificationComponent implements OnInit{
  @Input()
  notification:Notification|null;
  ngOnInit(): void {
  }
  constructor()
  {
    this.notification=null;
  }
  markAsRead()
  {

  }
  acceptTerm()
  {

  }
  declineTerm()
  {
    
  }

}
