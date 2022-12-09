import { HttpErrorResponse } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthenticationService } from './../../shared/services/authentication.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { UserForAuthenticationDto } from 'src/app/models/UserForAuthenticationDto';
import { AuthResponseDto } from 'src/app/models/AuthResponseDto';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  private returnUrl: string = "";
  isTfaEnabled: boolean = false;
  
  loginForm: FormGroup  = new FormGroup({
    email: new FormControl("", [Validators.required]),
    password: new FormControl("", [Validators.required])
  });

  tfaForm: FormGroup  = new FormGroup({
    tfaCode: new FormControl("", [Validators.required])
  });

  errorMessage: string = '';
  showError: boolean = false;
  email:string = "";

  constructor(
    private authService: AuthenticationService, 
    private router: Router, 
    private route: ActivatedRoute) { }
  
  ngOnInit(): void {
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  validateControl = (controlName: string) => {
    return this.loginForm.get(controlName)?.invalid && this.loginForm.get(controlName)?.touched
  }

  hasError = (controlName: string, errorName: string) => {
    return this.loginForm.get(controlName)?.hasError(errorName)
  }
  
  loginUser = (loginFormValue: any) => {
    this.showError = false;
    const login = {... loginFormValue };

    const userForAuth: UserForAuthenticationDto = {
      email: login.email,
      password: login.password
    }

    this.authService.loginUser(userForAuth)
    .subscribe({
      next: (res:AuthResponseDto) => {
       this.isTfaEnabled = res.isTfaEnabled;

       if(this.isTfaEnabled){
        this.router.navigate(['twostepverification'], 
          { queryParams: { returnUrl: this.returnUrl, email: login.email }})
       }
       else{
        localStorage.setItem("token", res.token);
        localStorage.setItem("email", login.email);
        this.router.navigate([this.returnUrl]);
       }
    },
    error: (err: HttpErrorResponse) => {
      this.errorMessage = err.message;
      this.showError = true;
    }})
  }
}