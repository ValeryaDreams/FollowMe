import { Component, OnInit } from '@angular/core';
import { PostsService } from '../services/posts.service';


@Component({
    selector: 'posts',
    templateUrl: './posts.component.html',
    styleUrl: './posts.component.css',
    standalone: false
})
export class PostsComponent implements OnInit {
    posts: any = [];

    constructor(private postsService: PostsService) { }

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
    }
}
