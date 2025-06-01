import type { Routes } from '@angular/router';
import {LeaderboardComponent} from './leaderboard.component';

export const LEADERBOARD_ROUTES: Routes = [
  {
    path: '',
    component: LeaderboardComponent,
    title: 'Leaderboard',
  },
  {
    path: 'home',
    loadChildren: () =>
      import('../../../home/pages/home/home.routes').then(m => m.HOME_ROUTES),
  }
];
