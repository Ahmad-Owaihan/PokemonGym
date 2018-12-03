import {Routes} from '@angular/router';
import { HomeComponent } from './home/home.component';
import { PokemonsComponent } from './pokemons/pokemons.component';
import { TournamentsComponent } from './tournaments/tournaments.component';
import { AdminComponent } from './admin/admin.component';
import { AuthGuard } from './_guards/auth.guard';

export const appRoutes: Routes = [
    {path: '', component: HomeComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            // {path: 'pokemons', component: PokemonsComponent},
            // {path: 'tournaments', component: TournamentsComponent},
        ]
    },
    {path: 'admin', component: AdminComponent},
    {path: 'pokemons', component: PokemonsComponent},
    {path: 'tournaments', component: TournamentsComponent},
    {path: '**', redirectTo: '', pathMatch: 'full'},
];
