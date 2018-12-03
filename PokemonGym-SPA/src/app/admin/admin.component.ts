import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AlertifyService } from '../_services/alertify.service';
import { TournamentService } from '../_services/tournament.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {
  model: any = {};
  tournaments: any;
  constructor(private http: HttpClient, private alertify: AlertifyService, private tournamentService: TournamentService) { }

  ngOnInit() {
    this.getTournaments();

  }

  getTournaments() {
    this.tournamentService.getTournaments().subscribe(data => {
      this.tournaments = data;
    }, error => {
      this.alertify.error(error);
    }, () => {
      // this.model = this.createRows(this.model);
    });
  }

  addScores() {
    this.tournamentService.addScore(this.model).subscribe(() => {
      this.alertify.success('Added Score for first row');
    }, error => this.alertify.error(error)
    );
  }

  createRows(participants) {
    this.model.list = [];
    let index = 0;
    participants.forEach(participant => {
      const element: any = {};
      element.participantId = participant.id;
      element.tournamentId = participant.tournamentId;
      element.row = [];
      participants.forEach(x => {
        element.row.push({'points': 0});
        index++;
      });
      this.model.list.push(element);
    });
    console.log(this.model.list);
  }
}
