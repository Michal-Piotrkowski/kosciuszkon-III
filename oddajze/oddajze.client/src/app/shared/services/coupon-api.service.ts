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
    console.log(`Using coupon with ID: ${JSON.stringify({ couponTemplateId: couponId })}`);
  
    return this.http.postSpecial('coupons/redeem', { couponTemplateId: couponId });
  }  

  getMyCoupons() {
    return this.http.get('Users/me/coupons');
  }
}
