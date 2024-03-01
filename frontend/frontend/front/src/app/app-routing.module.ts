import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { BcProfileComponent } from './bc-profile/bc-profile.component';
import { AdminProfileComponent } from './admin-profile/admin-profile.component';

const routes: Routes = [
  {path:'',component:LoginComponent},
  {path:'userProfile',component:UserProfileComponent},
  {path:'bcProfile',component:BcProfileComponent},
  {path:'adminProfile',component:AdminProfileComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
