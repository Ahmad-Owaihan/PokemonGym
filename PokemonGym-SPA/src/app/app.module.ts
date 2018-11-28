import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { BsDropdownModule } from 'ngx-bootstrap';

import { NavComponent } from './nav/nav.component';
import { RegisterComponent } from './register/register.component';
import { HttpClientModule } from '@angular/common/http';
import { AuthService } from './_services/auth.service';
import { ErrorInterceptorProvider } from './_services/error.intrerceptor';
import { AlertifyService } from './_services/alertify.service';

@NgModule({
   declarations: [
      AppComponent,
      HomeComponent,
      NavComponent,
      RegisterComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      BsDropdownModule.forRoot()
   ],
   providers: [
      AuthService,
      ErrorInterceptorProvider,
      AlertifyService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
