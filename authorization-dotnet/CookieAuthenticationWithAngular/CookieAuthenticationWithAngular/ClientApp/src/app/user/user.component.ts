import { Component } from '@angular/core';
import { AuthService } from '../auth/auth-service';
import { UserClaim } from '../auth/user-claim';

@Component({
    selector: 'app-user',
    templateUrl: './user.component.html',
})
export class UserComponent {
    userClaims: UserClaim[] = [];
    constructor(private authService: AuthService) {
        this.getUser();
    }

    getUser() {
        this.authService.user().subscribe(
            result => {
                this.userClaims = result;
            });
    }
}
