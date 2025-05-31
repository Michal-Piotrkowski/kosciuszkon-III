import { Component } from '@angular/core';
import { ZXingScannerModule } from '@zxing/ngx-scanner';
import { BarcodeFormat } from '@zxing/library';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-qr-scanner',
  templateUrl: './qr-scanner.component.html',
  styleUrls: ['./qr-scanner.component.scss'],
  imports: [ZXingScannerModule, CommonModule],

})

export class QrScannerComponent {
  qrResult: string | null = null;
  scannerEnabled = false;
  allowedFormats = [ BarcodeFormat.QR_CODE, BarcodeFormat.EAN_13, BarcodeFormat.CODE_128, BarcodeFormat.DATA_MATRIX /*, ...*/ ];
  scannerKey = 0;
  onScanSuccess($event: string) {
    this.qrResult = $event;
  }

  toggleScanner() {
    this.scannerEnabled = !this.scannerEnabled;
    this.qrResult = null;
    this.scannerKey++;
  }
}
