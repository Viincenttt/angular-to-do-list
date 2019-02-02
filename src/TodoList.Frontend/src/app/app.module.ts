import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HeaderComponent } from './components/header/header.component';
import { AuthService } from './services/authentication/auth.service';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { RegistrationService } from './services/registration.service';
import { HomeComponent } from './components/home/home.component';
import { TodoOverviewComponent } from './components/todo/todo-overview/todo-overview.component';
import { AuthGuard } from './services/authentication/auth.guard';
import { TodoListService } from './services/todolist.service';
import { JwtInterceptor } from './services/authentication/jwt.interceptor';


@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    LoginComponent,
    RegisterComponent,
    HomeComponent,
    TodoOverviewComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    NgbModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    AuthService,
    RegistrationService,
    TodoListService,
    AuthGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
