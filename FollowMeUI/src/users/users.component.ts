import { Component, OnInit } from '@angular/core';
import { User } from '../models/user';
import { UsersService } from '../services/users.service';


@Component({
    selector: 'users',
    templateUrl: './users.component.html',
    standalone: false
})
export class UsersComponent implements OnInit {
    users: User[] = [];

    constructor(private usersService: UsersService) { }

    ngOnInit() {
        this.usersService.getUsers().subscribe({
            next: (data) => {
                console.log(data);
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
