import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from "@angular/router";
import { Observable } from "rxjs/internal/Observable";
import { map } from "rxjs/operators";
import { AuthService } from "./auth-service";

@Injectable()
export class AuthGuard implements CanActivate {
    constructor(private authService: AuthService, private router: Router) { }

    canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        return this.isSignedIn();
    }

    isSignedIn(): Observable<boolean> {
        return this.authService.isSignedIn().pipe(
            map((isSignedIn) => {
                if (!isSignedIn) {
                    this.router.navigate(['signin']);
                    return false;
                }
                return true;
            }));
    }
}
