import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { NotificationService } from '../services/notification.service';

@Component({
  selector: 'app-list-notification',
  templateUrl: './list-notification.component.html',
  styleUrls: ['./list-notification.component.css']
})
export class ListNotificationComponent implements OnInit{

  arrNotification$:Observable<any>;
  ngOnInit(): void {
    this.arrNotification$=this.notService.getNotifications();
    this.arrNotification$.subscribe((x)=>console.log(x));
  }

  constructor(private notService:NotificationService)
  {
    this.arrNotification$=new Observable<any>();
  }

}
