import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { LoginComponent } from "./login/login.component";
import { UserProfileComponent } from "./user-profile/user-profile.component";
import { BcProfileComponent } from "./bc-profile/bc-profile.component";
import { AdminProfileComponent } from "./admin-profile/admin-profile.component";
import { CreateTermComponent } from "./create-term/create-term.component";
import { ListBordercrossComponent } from "./list-bordercross/list-bordercross.component";
import { UserSettingsComponent } from "./user-settings/user-settings.component";
import { CreateBCComponent } from "./create-bc/create-bc.component";
import { ListUserCardComponent } from "./list-user-card/list-user-card.component";
import { BcDeleteComponent } from "./bc-delete/bc-delete.component";
import { ListBcDeleteComponent } from "./list-bc-delete/list-bc-delete.component";
import { ListPersonalTermComponent } from "./list-personal-term/list-personal-term.component";
import { ListBcTermComponent } from "./list-bc-term/list-bc-term.component";
import { SignupComponent } from "./signup/signup.component";

const routes: Routes = [
  { path: "", component: LoginComponent },
  { path: "userProfile", component: UserProfileComponent },
  { path: "bcProfile", component: BcProfileComponent },
  { path: "adminProfile", component: AdminProfileComponent },
  { path: "createTerm", component: CreateTermComponent },
  { path: "AllBcs", component: ListBordercrossComponent },
  { path: "Settings", component: UserSettingsComponent },
  { path: "CreateBC", component: CreateBCComponent },
  {path:'AllUsers',component:ListUserCardComponent},
  {path:'deleteBC',component:ListBcDeleteComponent},
  {path:'PersonalTerms',component:ListPersonalTermComponent},
  {path:'BCTerm',component:ListBcTermComponent},
  {path:'SignUp',component:SignupComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
