import { Injectable, computed, signal } from '@angular/core';
import { ProfileApiService } from './profile-api.service';

@Injectable({
  providedIn: 'root',
})
export class UserPointsService {
  private usernameSignal = signal<string>('');
  private pointsSignal = signal<number>(0);

  username = computed(() => this.usernameSignal());
  points = computed(() => this.pointsSignal());

  constructor(private profileApi: ProfileApiService) {
    this.loadUserData();
  }


  loadUserData() {
    this.profileApi.getPoints().subscribe((res: any) => {
      this.usernameSignal.set(res.username);
      this.pointsSignal.set(res.totalPoints);
    });


  }

  refresh() {
    this.loadUserData();
  }
}
