import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { PostsService } from '../services/posts.service';
import { Post } from '../models/post';
import { AuthGuard } from '../services/authGuard.service';

@Component({
    selector: 'app-newpost',
    templateUrl: './newpost.component.html',
    styleUrls: ['./newpost.component.css'],
    standalone: false
})
export class NewPostComponent {
    newPost!: Post;

    postForm = new FormGroup({
        text: new FormControl('', [Validators.required, Validators.minLength(5)]),
    });

    constructor(private router: Router, private postService: PostsService, private authGuard: AuthGuard) { }

    onSubmit() {
        const currentUser = this.authGuard.getCurrentUser();
        if (currentUser) {
            this.newPost = {
                id: 0,
                date: new Date(),
                text: this.postForm.controls['text'].value as string,
                isGroup: false,
                userId: currentUser.id
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
        } else {
            console.log('Пользователь не авторизован');
        }
    }

    onCancel() {
        this.router.navigate(['/posts']);
    }
}
