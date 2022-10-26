import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserForRegistrationDto } from 'src/app/models/UserForRegistrationDto';
import { RegistrationResponseDto } from 'src/app/models/registrationResponseDto';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private http: HttpClient) { }

  public registerUser = (body: UserForRegistrationDto) => {
    return this.http.post<RegistrationResponseDto> (`${environment.apiUrl}/accounts/registration`, body);
  }

}
