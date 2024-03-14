import { NgModule, isDevMode } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { StoreModule } from '@ngrx/store';
import { loginReducer } from './ngrx/login.reducer';
import { AdminProfileComponent } from './admin-profile/admin-profile.component';
import { BcProfileComponent } from './bc-profile/bc-profile.component';
import {StoreDevtoolsModule} from '@ngrx/store-devtools';
import { CreateTermComponent } from './create-term/create-term.component';
import { BordercrossComponent } from './bordercross/bordercross.component';
import { ListBordercrossComponent } from './list-bordercross/list-bordercross.component';
import { UserSettingsComponent } from './user-settings/user-settings.component';
import { CreateBCComponent } from './create-bc/create-bc.component';
import { UserCardComponent } from './user-card/user-card.component';
import { ListUserCardComponent } from './list-user-card/list-user-card.component';
import { BcDeleteComponent } from './bc-delete/bc-delete.component';
import { ListBcDeleteComponent } from './list-bc-delete/list-bc-delete.component';
import { PersonalTermCardComponent } from './personal-term-card/personal-term-card.component';
import { ListPersonalTermComponent } from './list-personal-term/list-personal-term.component';
import { BcTermCardComponent } from './bc-term-card/bc-term-card.component';
import { ListBcTermComponent } from './list-bc-term/list-bc-term.component';
import { SignupComponent } from './signup/signup.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'


import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE, MAT_NATIVE_DATE_FORMATS, MatNativeDateModule, NativeDateAdapter } from '@angular/material/core';




@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    UserProfileComponent,
    AdminProfileComponent,
    BcProfileComponent,
    CreateTermComponent,
    BordercrossComponent,
    ListBordercrossComponent,
    UserSettingsComponent,
    CreateBCComponent,
    UserCardComponent,
    ListUserCardComponent,
    BcDeleteComponent,
    ListBcDeleteComponent,
    PersonalTermCardComponent,
    ListPersonalTermComponent,
    BcTermCardComponent,
    ListBcTermComponent,
    SignupComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatInputModule,
    MatFormFieldModule,
    StoreModule.forRoot({
      'login':loginReducer
    }),
    StoreDevtoolsModule.instrument({ maxAge: 25, logOnly: !isDevMode() }),
    StoreDevtoolsModule.instrument({
      maxAge: 25, // Retains last 25 states
      logOnly: !isDevMode(), // Restrict extension to log-only mode
      autoPause: true, // Pauses recording actions and state changes when the extension window is not open
      trace: false, //  If set to true, will include stack trace for every dispatched action, so you can see it in trace tab jumping directly to that part of code
      traceLimit: 75, // maximum stack trace frames to be stored (in case trace option was provided as true)
      connectOutsideZone: true // If set to true, the connection is established outside the Angular zone for better performance
    }),
    BrowserAnimationsModule,
  ],
  providers: [
    { provide: DateAdapter, useClass: NativeDateAdapter },
    { provide: MAT_DATE_FORMATS, useValue: MAT_NATIVE_DATE_FORMATS },
    { provide: MAT_DATE_LOCALE, useValue: 'sr' },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
