import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { User } from '../models/user';

@Injectable({
    providedIn: 'root'
})
export class AuthGuard implements CanActivate {

    private isLoggedIn = false;
    private currentUser: User | null = null;

    constructor(private router: Router, private http: HttpClient) { }

    canActivate(): boolean {
        if (this.isLoggedIn) {
            return true;
        } else {
            this.router.navigate(['/login']);
            return false;
        }
    }

    login(response: any) {
        console.log(response)
        this.isLoggedIn = true;
        this.currentUser = response; 
    }

    logout() {
        this.isLoggedIn = false;
        this.currentUser = null;
    }

    getCurrentUser(): User | null {
        return this.currentUser;
    }
}
