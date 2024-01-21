import { NgModule, isDevMode } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { BcprofileComponent } from './bcprofile/bcprofile.component';
import { AdminprofileComponent } from './adminprofile/adminprofile.component';
import { BorderCrossComponent } from './border-cross/border-cross.component';
import { ListBorderCrossComponent } from './list-border-cross/list-border-cross.component';
import { HomeComponent } from './home/home.component';
import { StoreModule } from '@ngrx/store';
import { BCNameReducer } from './reducer/bcname.reducer';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { BorderCrossInfoComponent } from './border-cross-info/border-cross-info.component';
import { CreateTerminComponent } from './create-termin/create-termin.component';
import { PersonalTermComponent } from './personal-term/personal-term.component';
import { ListPersonalTermComponent } from './list-personal-term/list-personal-term.component';
import { NotificationComponent } from './notification/notification.component';
import { ListNotificationComponent } from './list-notification/list-notification.component';
import { TermComponent } from './term/term.component';
import { ListTermComponent } from './list-term/list-term.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    UserProfileComponent,
    BcprofileComponent,
    AdminprofileComponent,
    BorderCrossComponent,
    ListBorderCrossComponent,
    HomeComponent,
    BorderCrossInfoComponent,
    CreateTerminComponent,
    PersonalTermComponent,
    ListPersonalTermComponent,
    NotificationComponent,
    ListNotificationComponent,
    TermComponent,
    ListTermComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule,
    StoreModule.forRoot({'bcname':BCNameReducer}),
    StoreDevtoolsModule.instrument({
      maxAge: 25, // Retains last 25 states
      logOnly: !isDevMode(), // Restrict extension to log-only mode
      autoPause: true, // Pauses recording actions and state changes when the extension window is not open
      trace: false, // If set to true, will include stack trace for every dispatched action, so you can see it in trace tab jumping directly to that part of code
      traceLimit: 75, // maximum stack trace frames to be stored (in case trace option was provided as true)// If set to true, the connection is established outside the Angular zone for better performance
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
