import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CalculateRoundScores } from '../../data/request-bodies/calculate-round-scores';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RoundScoreService {

  constructor(private client: HttpClient, @Inject('BASE_API_URL') private baseUrl: string) {

  }

  calculateRoundScores(calculateRoundScores: CalculateRoundScores): Observable<any> {
    let body = JSON.stringify(calculateRoundScores);
    return this.client.post(`${this.baseUrl}/api/game/round-scores/calculate`, body, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json; charset=utf-8',
      }),
      responseType: 'json'
    });
  }
}
