import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Post } from "../models/post";

@Injectable({
	providedIn: 'root'
})

export class PostsService {

	constructor(private http: HttpClient) { }

	getAllPosts() {
		return this.http.get<Post>('https://followkraken.somee.com/Posts/GetAllPosts');
	}

	createPost(newPost: Post) {
		return this.http.post<Post>('https://followkraken.somee.com/Posts/CreatePost', newPost)
	}

}