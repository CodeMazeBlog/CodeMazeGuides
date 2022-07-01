import { HttpClient, HttpEvent } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, of } from "rxjs";
import { catchError, map } from "rxjs/operators";


@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private http: HttpClient) {
  }

  public signIn(email: string, password: string) {
    return this.http.post<Response>('api/signin', {
      email: email,
      password: password
    });
  }

  public signOut() {
    return this.http.get('api/signout');
  }

  public user() {
    return this.http.get<UserClaim[]>('api/user');
  }

  public isSignedIn(): Observable<boolean> {
    return this.user().pipe(
      map((userClaims) => {
        let hasClaims = userClaims.length > 0;
        return !hasClaims ? false : true;
      }),
      catchError((error) => {
        return of(false);
      }));
  }
}

export interface UserClaim {
  type: string;
  value: string;
}

export interface Response {
  isSuccess: boolean;
  message: string;
}
