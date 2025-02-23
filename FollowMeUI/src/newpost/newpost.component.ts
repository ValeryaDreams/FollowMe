import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { PostsService } from '../services/posts.service';
import { Post } from '../models/post';

@Component({
    selector: 'app-newpost',
    templateUrl: './newpost.component.html',
    styleUrl: './newpost.component.css',
    standalone: false
})
export class NewPostComponent {
    newPost!: Post;

    postForm = new FormGroup({
        text: new FormControl('', [Validators.required, Validators.minLength(5)]),
    });

    constructor(private router: Router, private postService: PostsService) { }

    onSubmit() {
        this.newPost = {
            id: 0,
            date: new Date(),
            text: this.postForm.controls['text'].value as string,
            isGroup: false,
            userid: 1
        };

        this.postService.createPost(this.newPost).subscribe({
            next: (data) => {
                console.log(data);
            },
            error: (err) => {
                console.log(err);
            },
            complete: () => {
                console.log("Post created successfully!");
                this.router.navigate(['/posts']);
            }
        });

        
    }

    onCancel() {
        this.router.navigate(['/posts']);
    }
}
