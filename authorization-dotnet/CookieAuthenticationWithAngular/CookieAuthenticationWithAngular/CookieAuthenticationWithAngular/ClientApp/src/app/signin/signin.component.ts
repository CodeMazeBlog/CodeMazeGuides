import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../auth/auth-service';

@Component({
  selector: 'app-signin-component',
  templateUrl: './signin.component.html'
})
export class SignInComponent implements OnInit {
  loginForm!: FormGroup;
  authFailed: boolean = false;
  signedIn: boolean = false;
  constructor(private authService: AuthService,
    private formBuilder: FormBuilder,
    private router: Router) {
    this.authService.isSignedIn().subscribe(
      isSignedIn => {
        this.signedIn = isSignedIn;
      });
  }

  ngOnInit(): void {
    this.authFailed = false;
    this.loginForm = this.formBuilder.group(
      {
        email: ['', [Validators.required, Validators.email]],
        password: ['', [Validators.required]]
      });
  }

  public signin(event: any) {
    if (!this.loginForm.valid) {
      return;
    }

    this.authService.signIn(this.loginForm.get('email')?.value, this.loginForm.get('password')?.value).subscribe(
      response => {
        console.debug(response);
        if (response.isSuccess) {
          this.router.navigateByUrl('user')
        } else {
          this.authFailed = true;
        }
      });
  }
}
