import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class TournamentService {

  baseUrl = 'http://localhost:5000/api/tournament/';

constructor(private http: HttpClient) { }

getTournaments() {
  return this.http.get(this.baseUrl);
}

createTournament(model: any) {
  return this.http.post(this.baseUrl + 'create', model).pipe(map(data => {}));
}

deleteTournament(id) {
  return this.http.delete(this.baseUrl + id);
}

startTournament(id) {
  return this.http.post(this.baseUrl + 'start/' + id, id);
}

stopTournament(id) {
  return this.http.post(this.baseUrl + 'stop/' + id, id);
}

join(model: any) {
  return this.http.post(this.baseUrl + 'join', model).pipe(map(data => {}));
}


public leave(model: any) {
  const options = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
    body: model,
  };

  return this.http.delete(this.baseUrl + 'leave', options);
}

addScore(model: any) {
  return this.http.post(this.baseUrl + 'scorerow', model);
}

}
