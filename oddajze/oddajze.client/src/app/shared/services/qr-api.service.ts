import { inject, Injectable } from '@angular/core';
import { HttpService } from './http.service';

@Injectable({
  providedIn: 'root'
})
export class QrApiService {
  private http: HttpService = inject(HttpService);
  constructor() { }

  postQrCode(data: string) {
    return this.http.post('qr', { data });
  }
}
