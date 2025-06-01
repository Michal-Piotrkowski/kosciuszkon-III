import { Component, inject, input, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Coupon } from '../../../../shared/models/coupon.model';
import { CouponApiService } from '../../../../shared/services/coupon-api.service';
import { firstValueFrom } from 'rxjs';

@Component({
  selector: 'app-coupon-item',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './coupon-item.component.html',
  styleUrls: ['./coupon-item.component.scss']
})
export class CouponItemComponent {
  private couponApi = inject(CouponApiService);
  coupon = input<Coupon | null>(null);

  expand = signal(false);
  isLoading = signal(false);
  feedbackMessage = signal('');
  toggleExpand(): void {
    this.expand.update(value => !value);
    this.feedbackMessage.set('');
  }

  async useCoupon(): Promise<void> {
    const coupon = this.coupon();
    if (!coupon?.available || this.isLoading()) return;

    this.isLoading.set(true);
    this.feedbackMessage.set('');

    try {
      const response = await firstValueFrom(this.couponApi.useCoupon(coupon.id));
      console.log('Response z użycia kuponu:', response);

      const myCoupons = await firstValueFrom(this.couponApi.getMyCoupons());
      console.log('Moje kupony:', myCoupons);

      this.feedbackMessage.set('Kupon pomyślnie użyty!');
    } catch (error: any) {
      console.error('Błąd podczas używania kuponu:', error);
      this.feedbackMessage.set('Coś poszło nie tak, spróbuj ponownie.');
    } finally {
      this.isLoading.set(false);
    }
  }
  
}
