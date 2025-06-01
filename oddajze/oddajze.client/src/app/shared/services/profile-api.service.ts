import { inject, Injectable } from '@angular/core';
import { HttpService } from './http.service';

@Injectable({
  providedIn: 'root'
})
export class ProfileApiService {
  private http: HttpService = inject(HttpService);
  constructor() { }

  getLastReturns(){
    this.http.get('Users/lastReturns');
  }

  getPoints() {
    this.http.get('Users/me');
  }
}
