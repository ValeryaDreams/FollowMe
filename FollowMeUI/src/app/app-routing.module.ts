import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { UsersComponent } from '../users/users.component';
import { PostsComponent } from '../posts/posts.component';
import { NewPostComponent } from '../newpost/newpost.component';

const routes: Routes = [
	    { path: '', component: AppComponent },
	    { path: 'users', component: UsersComponent },
	    { path: 'posts', component: PostsComponent },
	    { path: 'createPost', component: NewPostComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
