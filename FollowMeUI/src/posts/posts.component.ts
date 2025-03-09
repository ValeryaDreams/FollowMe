import { Component, OnInit } from '@angular/core';
import { PostsService } from '../services/posts.service';
import { UsersService } from '../services/users.service';


@Component({
    selector: 'posts',
    templateUrl: './posts.component.html',
    styleUrl: './posts.component.css',
    standalone: false
})
export class PostsComponent implements OnInit {
    posts: any = [];
    users: any = [];

    constructor(private postsService: PostsService, private userService: UsersService) { }

    ngOnInit() {
        this.postsService.getAllPosts().subscribe({
            next: (data) => {
                this.posts = data;
            },
            error: (err) => {
                console.log(err);
            },
            complete: () => {
                console.log("Data loading successfully!");
            }
        });

        this.userService.getUsers().subscribe({
            next: (data) => {
                this.users = data;
            },
            error: (err) => {
                console.log(err);
            },
            complete: () => {
                console.log("Data loading successfully!");
            }
        });
    }

    getUserFullName(userId: number): string {
        const user = this.users.find((u: { id: number; }) => u.id === userId);
        return user ? user.name : 'Unknown';
    }
}
