import { Component } from '@angular/core';
import { AuthService } from '../auth/auth-service';

@Component({
    selector: 'app-signout-component',
    templateUrl: './signout.component.html'
})
export class SignOutComponent {
    constructor(private authService: AuthService) {
        this.signout();
    }

    public signout() {
        this.authService.signOut().subscribe();
    }
}
