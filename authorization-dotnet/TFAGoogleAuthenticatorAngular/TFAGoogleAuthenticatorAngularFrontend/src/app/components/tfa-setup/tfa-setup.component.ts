import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { TfaSetupDto } from 'src/app/models/TfaSetupDto';
import { AuthenticationService } from 'src/app/shared/services/authentication.service';

@Component({
  selector: 'app-tfa-setup',
  templateUrl: './tfa-setup.component.html',
  styleUrls: ['./tfa-setup.component.css']
})
export class TfaSetupComponent implements OnInit {

  tfaForm: FormGroup  = new FormGroup({
    code: new FormControl("", [Validators.required])
  });

  isLoading: boolean = true;
  tfaEnabled: boolean = false;
  showError: boolean = false;
  errorMessage: string = "";
  qrInfo: string = "";
  authenticatorKey: string = "";

  constructor(public authService: AuthenticationService) { }

  ngOnInit(): void {
    let email = localStorage.getItem("email") ?? '';
    this.authService.getTfaSetup(email)
      .subscribe((response:TfaSetupDto) => {
        this.tfaEnabled = response.isTfaEnabled ?? false;
        this.qrInfo = response.formattedKey ?? '';
        this.authenticatorKey = response.authenticatorKey ?? '';
        this.isLoading = false;
      }
    );
  }

  validateControl = (controlName: string) => {
    return this.tfaForm.get(controlName)?.invalid && this.tfaForm.get(controlName)?.touched
  }

  hasError = (controlName: string, errorName: string) => {
    return this.tfaForm.get(controlName)?.hasError(errorName)
  }

  disableTfa = () => {
    let email = localStorage.getItem("email") ?? '';
    this.authService.disableTfa(email)
    .subscribe({
      next: (res:any) => {
        this.tfaEnabled = false;
      },
      error: (err: HttpErrorResponse) => {
        this.showError = true;
        this.errorMessage = "Two-factor authentication was not disabled for this account (Message: " + err.message + ")";
      }})
  }

  enableTfa = (tfaFormValue: any) => {
    const tfaForm = {... tfaFormValue };

    const tfaSetupDto: TfaSetupDto = {
      email: localStorage.getItem("email") ?? '',
      code: tfaForm.code
    }

    this.authService.postTfaSetup(tfaSetupDto)
    .subscribe({
      next: (res:any) => {
        this.tfaEnabled = true;
      },
      error: (err: HttpErrorResponse) => {
        this.showError = true;
        this.errorMessage = "Two-factor authentication was not activated for this account (Message: " + err.message + ")";
      }})
  }  
}
