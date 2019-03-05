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
import { RouterModule } from '@angular/router';
import { appRoutes } from './router';
import { PokemonsComponent } from './pokemons/pokemons.component';
import { TournamentsComponent } from './tournaments/tournaments.component';
import { AdminComponent } from './admin/admin.component';
import { AuthGuard } from './_guards/auth.guard';
import { TournamentService } from './_services/tournament.service';
import { AdminGuard } from './_guards/admin.guard';

@NgModule({
   declarations: [
      AppComponent,
      HomeComponent,
      NavComponent,
      RegisterComponent,
      PokemonsComponent,
      TournamentsComponent,
      AdminComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      BsDropdownModule.forRoot(),
      RouterModule.forRoot(appRoutes)
   ],
   providers: [
      AuthService,
      ErrorInterceptorProvider,
      AlertifyService,
      AuthGuard,
      AdminGuard,
      TournamentService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
