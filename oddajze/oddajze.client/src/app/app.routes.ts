import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: 'home',
    loadChildren: () =>
      import('./features/home/pages/home/home.routes').then(m => m.HOME_ROUTES),
  },
  {
    path: 'qr-scanner',
    loadChildren: () =>
      import('./features/qr-scanner/pages/qr-scanner.routes').then(m => m.QR_ROUTES),
  },
  {
    path: 'leaderboard',
    loadChildren: () =>
    import('./features/leaderboard/pages/leaderboard/leaderboard.routes').then(m => m.LEADERBOARD_ROUTES)
  },
  {
    path: 'coupon',
    loadChildren: () =>
    import('./features/coupon/pages/coupon.route').then(m => m.COUPON_ROUTES),
  },
  {
    path: '**',
    redirectTo: 'home',
    pathMatch: 'full',
  }
];
