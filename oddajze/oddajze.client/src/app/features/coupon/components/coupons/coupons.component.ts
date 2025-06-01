import { Component, signal, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Coupon } from '../../../../shared/models/coupon.model';
import { CouponItemComponent } from '../coupon-item/coupon-item.component';
import { CouponApiService } from '../../../../shared/services/coupon-api.service';

@Component({
  selector: 'app-coupons',
  standalone: true,
  imports: [CommonModule, CouponItemComponent],
  templateUrl: './coupons.component.html',
  styleUrls: ['./coupons.component.scss']
})
export class CouponsComponent {
  coupons = signal<Coupon[]>([]);
  private couponApi = inject(CouponApiService);

  constructor() {
    this.loadCoupons();
  }

  loadCoupons() {
    this.couponApi.getCoupons().subscribe({
      next: (coupons: Coupon[]) => {
        this.coupons.set(coupons);
      },
      error: (err) => {
        console.error('Błąd podczas pobierania kuponów:', err);
      }
    });
  }
}
