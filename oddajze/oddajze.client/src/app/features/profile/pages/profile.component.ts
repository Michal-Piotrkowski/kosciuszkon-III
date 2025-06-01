import { Component, inject, OnInit, signal, TrackByFunction } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProfileApiService } from '../../../shared/services/profile-api.service';
import { environment } from '../../../../environment/environment';
import { User } from '../../../shared/models/user.models';

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {
  private profileApiService = inject(ProfileApiService);

  env = environment;

  points = signal<number>(0);
  user = signal<User | null>(null);

  lastReturns = signal<any[]>([]);
  userCoupons = signal<any[]>([]);

  ngOnInit(): void {

    this.profileApiService.getMe().subscribe({
      next: (data: User) => {
        this.user.set(data);
        this.points.set(data.totalPoints);
      },
      error: err => console.error('Błąd przy pobieraniu danych użytkownika:', err)
    });

    this.profileApiService.getLastReturns().subscribe({
      next: data => this.lastReturns.set(data),
      error: err => console.error('Błąd przy pobieraniu zwrotów:', err)
    });

    this.profileApiService.getMeCoupons().subscribe({
      next: data => this.userCoupons.set(data),
      error: err => console.error('Błąd przy pobieraniu kuponów:', err)
    });
  }

  trackByReturn: TrackByFunction<any> = (index, item) => item.name;
  trackByCoupon: TrackByFunction<any> = (index, item) => item.name;
}
