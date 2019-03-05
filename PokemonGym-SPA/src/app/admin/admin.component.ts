import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AlertifyService } from '../_services/alertify.service';
import { TournamentService } from '../_services/tournament.service';
import { CanActivate, Router} from '@angular/router';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {
  model: any = {};
  data: any = []; // store model for tournaments
  tournaments: any;
  isEditing: any = [];

  constructor(private http: HttpClient, private alertify: AlertifyService,
     private tournamentService: TournamentService, private router: Router) { }

  ngOnInit() {
    this.getTournaments();

  }

  getTournaments() {
    this.tournamentService.getTournaments().subscribe(data => {
      this.tournaments = data;
    }, error => {
      this.alertify.error(error);
    }, () => {
      // after getting all tournaments
      this.isEditing = [];
      this.tournaments.forEach(tournament => {
        this.isEditing.push(false);
      });
    });
  }

  createTournament() {
    this.tournamentService.createTournament(this.model).subscribe(() => {
      this.alertify.success('created a new tournament');
    }, error => {
      this.alertify.error(error);
    }, () => {
      // after tournament is created
      this.ngOnInit();
    });
  }

  deleteTournament(id) {
    this.tournamentService.deleteTournament(id).subscribe(() => {
      this.alertify.success('deleted tournament successfuly');
    }, error => {
      this.alertify.error(error);
    }, () => {
      // after delete
      this.ngOnInit();
    });
  }

  startTournament(id) {
    this.tournamentService.startTournament(id).subscribe(() => {
      this.alertify.success('tournament started!');
    }, error => {
      this.alertify.error(error);
    }, () => {
      // after its done
      this.ngOnInit();
    });
  }

  stopTournament(id) {
    this.tournamentService.stopTournament(id).subscribe(() => {
      this.alertify.success('tournament stopped!');
    }, error => {
      this.alertify.error(error);
    }, () => {
      // after its done
      this.ngOnInit();
    });
  }

  addScores() {
    this.tournamentService.addScore(this.model).subscribe(() => {
      this.alertify.success('Added Score for first row');
    }, error => {
      this.alertify.error(error);
    }, () => {
      // after updating
      this.ngOnInit();
    });
  }

  createRows(tournament) {
    this.isEdit(tournament);
    this.model.list = [];
    let index = 0;
    tournament.participants.forEach(participant => {
      const element: any = {};
      element.participantId = participant.id;
      element.tournamentId = participant.tournamentId;
      element.row = [];
      tournament.participants.forEach(x => {
        element.row.push({'points': 0});
        index++;
      });
      this.model.list.push(element);
    });
  }

  isEdit(tournament) {
    const index = this.tournaments.findIndex(x => x.id === tournament.id);
    this.isEditing[index] = true;
  }

}
