import { inject, Injectable } from '@angular/core';
import { HttpService } from './http.service';

@Injectable({
  providedIn: 'root'
})
export class ProfileApiService {
  private http: HttpService = inject(HttpService);
  constructor() { }

  getLastReturns(){
    return this.http.get('Users/lastReturns');
  }

  getPoints() {
    return this.http.get('Users/me');
  }

  getMeCoupons() {
    return this.http.get('Users/me/coupons');
  }

  getMe(){
    return this.http.get('Users/me');
  }
}
