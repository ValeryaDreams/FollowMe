import { Component, OnInit, signal } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { AuthGuard } from '../services/authGuard.service';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css'],
    standalone: false
})
export class LoginComponent implements OnInit {

    hide = signal(true);
    clickEvent(event: MouseEvent) {
        this.hide.set(!this.hide());
        event.stopPropagation();
    }

    loginForm = new FormGroup({
        login: new FormControl('', Validators.required),
        password: new FormControl('', Validators.required)
    });

    constructor(private http: HttpClient, private router: Router, private authGuard: AuthGuard) { }

    ngOnInit(): void {
    }

    onSubmit() {
        this.http.post('https://followkraken.somee.com/api/Auth/login', this.loginForm.value)
            .subscribe(response => {
                if (response) {
                    this.authGuard.login(response); // передать информацию о пользователе
                    this.router.navigate(['/posts']);
                } else {
                    console.log('Ќеправильный логин или пароль');
                }
            });
    }
}
