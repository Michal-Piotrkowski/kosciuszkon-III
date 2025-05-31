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
    path: '**',
    redirectTo: 'home',
    pathMatch: 'full',
  }
];
