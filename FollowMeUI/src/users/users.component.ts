import { Component, OnInit } from '@angular/core';
import { User } from '../models/user';
import { UsersService } from '../services/users.service';


@Component({
    selector: 'users',
    templateUrl: './users.component.html',
    standalone: false
})
export class UsersComponent implements OnInit {
    users: any = [];

    constructor(private usersService: UsersService) { }

    ngOnInit() {
        this.usersService.getUsers().subscribe({
            next: (data) => {
                this.users = data;
                console.log(this.users);
            },
            error: (err) => {
                console.log(err);
            },
            complete: () => {
                console.log("Data loading successfully!");
            }
        });
    }

}
