import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterUserComponent } from './components/register-user/register-user.component';
import { TfaSetupComponent } from './components/tfa-setup/tfa-setup.component';
import { TwoStepVerificationComponent } from './components/two-step-verification/two-step-verification.component';
import { AuthGuard } from './helpers/authGuard';

const routes: Routes = [
  { path: '', component: HomeComponent, canActivate: [AuthGuard]  },
  { path: 'register', component: RegisterUserComponent  },
  { path: 'login', component: LoginComponent },
  { path: 'twostepverification', component: TwoStepVerificationComponent },
  { path: 'tfa-setup', component: TfaSetupComponent, canActivate: [AuthGuard]  }
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
