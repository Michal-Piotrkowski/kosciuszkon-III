import { Component, inject } from '@angular/core';
import { ZXingScannerModule } from '@zxing/ngx-scanner';
import { BarcodeFormat } from '@zxing/library';
import { CommonModule } from '@angular/common';
import { QrApiService } from '../../../shared/services/qr-api.service';
import { UserPointsService } from '../../../shared/services/user-points.service';
import {timer} from 'rxjs'; // <--- dodaj to


@Component({
  selector: 'app-qr-scanner',
  templateUrl: './qr-scanner.component.html',
  styleUrls: ['./qr-scanner.component.scss'],
  imports: [ZXingScannerModule, CommonModule],

})

export class QrScannerComponent {
  private qrApi: QrApiService = inject(QrApiService);
  private userPointsService = inject(UserPointsService);
  qrResult: string | null = null;
  scannerEnabled = false;
  allowedFormats = [ BarcodeFormat.QR_CODE, BarcodeFormat.EAN_13, BarcodeFormat.CODE_128, BarcodeFormat.DATA_MATRIX /*, ...*/ ];
  scannerKey = 0;

 onScanSuccess($event: string) {
  if (!this.scannerEnabled) return;

  this.qrApi.postQrCode($event).subscribe({
    next: (response) => {
      alert('✅ Kod zeskanowany pomyślnie!');
      timer(1000).subscribe(() => {
        this.userPointsService.refresh();
      });
      this.qrResult = response.data;
      this.toggleScanner();
    },
    error: (error) => {
      if (error.status === 400 || error.status === 500) {
        alert('❌ Ten kod został już użyty.');
      } else {
        alert('⚠️ Wystąpił nieoczekiwany błąd.');
      }
      this.toggleScanner();
    }
  });
}


  toggleScanner() {
    this.scannerEnabled = !this.scannerEnabled;
    this.qrResult = null;
    this.scannerKey++;
  }
}
