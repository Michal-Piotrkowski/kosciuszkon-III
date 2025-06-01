import { Component, OnInit } from '@angular/core';
import { SmallPanelComponent } from '../../../../shared/components/small-panel/small-panel.component';
import { HttpService } from '../../../../shared/services/http.service';
import { RankingUser } from '../../../../shared/models/ranking-user.model';
import {Observable} from 'rxjs';
import {NgClass, NgForOf} from '@angular/common';

@Component({
  selector: 'app-leaderboard',
  imports: [
    NgForOf,
    NgClass,
  ],
  templateUrl: './leaderboard.component.html',
  styleUrl: './leaderboard.component.scss'
})
export class LeaderboardComponent implements OnInit {
  constructor(private http: HttpService) {}

  ranking: RankingUser[] = [];

  ngOnInit(): void {
    this.getAllRankings().subscribe({
      next: (data: RankingUser[]) => {
        this.ranking = data;
        this.ranking.forEach(user => {
          console.log(`${user.id} Użytkownik: ${user.username}, Punkty: ${user.totalPoints}`);
        });
      },
      error: (error) => console.error('Błąd podczas pobierania rankingów:', error)
    })
  }

  getAllRankings(): Observable<RankingUser[]> {
    return this.http.get('Users/ranking');
  }


}
