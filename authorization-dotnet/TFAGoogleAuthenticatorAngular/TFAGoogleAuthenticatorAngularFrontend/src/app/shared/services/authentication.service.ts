import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserForRegistrationDto } from 'src/app/models/UserForRegistrationDto';
import { environment } from 'src/environments/environment';
import { AuthResponseDto } from 'src/app/models/AuthResponseDto';
import { UserForAuthenticationDto } from 'src/app/models/UserForAuthenticationDto';
import { TfaSetupDto } from 'src/app/models/TfaSetupDto';
import { RegistrationResponseDto } from 'src/app/models/RegistrationResponseDto';
import { TfaDto } from 'src/app/models/tfaDto';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private http: HttpClient) { }

  public registerUser = (body: UserForRegistrationDto) => {
    return this.http.post<RegistrationResponseDto> (`${environment.apiUrl}/accounts/registration`, body);
  }

  public getTfaSetup = (email: string) => {
    return this.http.get<TfaSetupDto> (`${environment.apiUrl}/accounts/tfa-setup?email=${email}`);
  }

  public postTfaSetup = (body: TfaSetupDto) => {
    return this.http.post<TfaSetupDto> (`${environment.apiUrl}/accounts/tfa-setup`, body);
  }

  public disableTfa = (email: string) => {
    return this.http.delete<TfaSetupDto> (`${environment.apiUrl}/accounts/tfa-setup?email=${email}`);
  }

  public loginUser = (body: UserForAuthenticationDto) => {
    return this.http.post<AuthResponseDto>(`${environment.apiUrl}/accounts/login`, body);
  }

  public loginUserTfa = (body: TfaDto) => {
    return this.http.post<AuthResponseDto>(`${environment.apiUrl}/accounts/login-tfa`, body);
  }

}
