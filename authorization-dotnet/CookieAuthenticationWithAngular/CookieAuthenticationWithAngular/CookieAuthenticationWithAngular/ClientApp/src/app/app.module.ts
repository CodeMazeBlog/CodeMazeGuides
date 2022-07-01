import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { Router, RouterModule } from '@angular/router';

import { AuthInterceptor } from './auth/auth-interceptor';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { SignInComponent } from './signin/signin.component';
import { SignOutComponent } from './signout/signout.component';
import { UserComponent } from './user/user.component';
import { SecuredComponent } from './secured/secured.component';
import { AuthGuard } from './auth/auth-guard';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    UserComponent,
    SignInComponent,
    SignOutComponent,
    SecuredComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      {
        path: '',
        redirectTo: 'signin',
        pathMatch: 'full'
      },
      {
        path: 'user',
        component: UserComponent,
        pathMatch: 'full'
      },
      {
        path: 'signin',
        component: SignInComponent,
        pathMatch: 'full'
      },
      {
        path: 'signout',
        component: SignOutComponent,
        pathMatch: 'full'
      },
      {
        path: 'secured',
        component: SecuredComponent,
        pathMatch: 'full',
        canActivate: [AuthGuard]
      }
    ])
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useFactory: function (router: Router) {
        return new AuthInterceptor(router);
      },
      multi: true,
      deps: [Router]
    },
    AuthGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
