import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserForRegistrationDto } from 'src/app/models/UserForRegistrationDto';
import { RegistrationResponseDto } from 'src/app/models/registrationResponseDto';
import { environment } from 'src/environments/environment';
import { AuthResponseDto } from 'src/app/models/AuthResponseDto';
import { UserForAuthenticationDto } from 'src/app/models/UserForAuthenticationDto';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private http: HttpClient) { }

  public registerUser = (body: UserForRegistrationDto) => {
    return this.http.post<RegistrationResponseDto> (`${environment.apiUrl}/accounts/registration`, body);
  }

  public loginUser = (route: string, body: UserForAuthenticationDto) => {
    return this.http.post<AuthResponseDto>(`${environment.apiUrl}/accounts/login`, body);
  }
}
