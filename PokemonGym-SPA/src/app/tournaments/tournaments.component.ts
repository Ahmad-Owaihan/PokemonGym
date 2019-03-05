import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TournamentService } from '../_services/tournament.service';
import { AlertifyService } from '../_services/alertify.service';
import { AuthService } from '../_services/auth.service';


@Component({
  selector: 'app-tournaments',
  templateUrl: './tournaments.component.html',
  styleUrls: ['./tournaments.component.css']
})
export class TournamentsComponent implements OnInit {

  model: any = {};
  tournaments: any;
  user$;
  constructor(private tournamentService: TournamentService, private alertify: AlertifyService, private authService: AuthService) { }

  ngOnInit() {
    this.getTournaments();
  }

  leave(id) {
    this.model.userId = this.authService.decodedToken.nameid;
    this.model.tournamentId = id;
    console.log(this.model);
    this.tournamentService.leave(this.model).subscribe(() => {
      this.alertify.success('You left the tournament!');
    }, error => {
      this.alertify.error(error);
    }, () => {
      this.ngOnInit();
    });
  }

  joinTournament(id) {
    this.model.userId = this.authService.decodedToken.nameid;
    this.model.tournamentId = id;
    this.tournamentService.join(this.model).subscribe(() => {
      this.alertify.success('You joined the tournament!');
    }, error => {
      this.alertify.error(error);
    }, () => {
      this.ngOnInit();
    });
  }

  getTournaments() {
    this.tournamentService.getTournaments().subscribe(
      data => this.tournaments = data
    );
  }

  getTournamentId(id) {
    return id;
  }
}
