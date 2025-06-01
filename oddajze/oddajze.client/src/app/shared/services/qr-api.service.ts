import { inject, Injectable } from '@angular/core';
import { HttpService } from './http.service';
import { HttpClient, HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class QrApiService {
  private http: HttpService = inject(HttpService);
  constructor() { }

 postQrCode(data: string) {
  const params = new HttpParams().set('qrCode', data);
  return this.http.post('Users/redeem', null, { params });
}
}
