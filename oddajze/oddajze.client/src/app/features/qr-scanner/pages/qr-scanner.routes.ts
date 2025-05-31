import type { Routes } from '@angular/router';
import { QrScannerComponent } from './qr-scanner.component';

export const QR_ROUTES: Routes = [
  {
    path: '',
    component: QrScannerComponent,
    title: 'Scanner QR',
  },
  {
    path: 'home',
    loadChildren: () =>
      import('../../home/pages/home/home.routes').then(m => m.HOME_ROUTES),
  }
];
