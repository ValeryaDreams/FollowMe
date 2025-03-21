import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';

import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { HomeComponent } from '../home/home.component';
import { UsersComponent } from '../users/users.component';
import { PostsComponent } from '../posts/posts.component';
import { NewPostComponent } from '../newpost/newpost.component';

import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { LoginComponent } from '../login/login.component';

@NgModule({
  declarations: [
        AppComponent,
        LoginComponent,
        HomeComponent,
        UsersComponent,
        PostsComponent,
        NewPostComponent
  ],
  imports: [
      BrowserModule,      
      AppRoutingModule,      
      MatIconModule,
      MatCardModule,
      FormsModule,
      ReactiveFormsModule,
      MatButtonModule,
      MatInputModule,
      HttpClientModule,

  ],
  providers: [
    provideAnimationsAsync()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
