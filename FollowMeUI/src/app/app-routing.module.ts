import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UsersComponent } from '../users/users.component';
import { PostsComponent } from '../posts/posts.component';
import { NewPostComponent } from '../newpost/newpost.component';
import { HomeComponent } from '../home/home.component';
import { LoginComponent } from '../login/login.component';
import { AuthGuard } from '../services/authGuard.service';

const routes: Routes = [
	{ path: 'login', component: LoginComponent },
	{ path: 'users', component: UsersComponent },
	{ path: 'posts', component: PostsComponent, canActivate: [AuthGuard] },
	{ path: 'createPost', component: NewPostComponent },
	{ path: '', redirectTo: '/login', pathMatch: 'full' }
];

@NgModule({
	imports: [RouterModule.forRoot(routes)],
	exports: [RouterModule]
})
export class AppRoutingModule { }
