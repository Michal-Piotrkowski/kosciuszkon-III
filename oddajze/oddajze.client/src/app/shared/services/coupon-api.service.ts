import { inject, Injectable } from '@angular/core';
import { HttpService } from './http.service';
import { environment } from '../../../environment/environment';

@Injectable({
  providedIn: 'root'
})
export class CouponApiService {
  private http: HttpService = inject(HttpService);
  private apiUrlS = environment.apiUrlSpecial;
  constructor() { }

  getCoupons(){
    return this.http.getSpecial(`coupons/templates`);
  }

  useCoupon(couponId: number) {
    return this.http.postSpecial('coupons/redeem', { couponId });
  }

  getMyCoupons() {
    return this.http.getSpecial('Users/me/coupons');
  }
}
