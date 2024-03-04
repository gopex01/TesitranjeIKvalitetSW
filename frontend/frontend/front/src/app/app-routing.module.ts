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
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
