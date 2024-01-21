import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { LoginComponent } from './login/login.component';
import { BcprofileComponent } from './bcprofile/bcprofile.component';
import { AdminprofileComponent } from './adminprofile/adminprofile.component';
import { ListBorderCrossComponent } from './list-border-cross/list-border-cross.component';
import { HomeComponent } from './home/home.component';
import { BorderCrossInfoComponent } from './border-cross-info/border-cross-info.component';
import { CreateTerminComponent } from './create-termin/create-termin.component';
import { ListPersonalTermComponent } from './list-personal-term/list-personal-term.component';

const routes: Routes = [
  {path:'userprofile',component:UserProfileComponent},
  {path:'login',component:LoginComponent},
  {path:'',component:HomeComponent},
  {path:'bcprofile',component:BcprofileComponent},
  {path:'adminprofile',component:AdminprofileComponent},
  {path:'allbcs',component:ListBorderCrossComponent},
  {path:'bcinfo',component:BorderCrossInfoComponent},
  {path:'createterm',component:CreateTerminComponent},
  {path:'personalterms',component:ListPersonalTermComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
