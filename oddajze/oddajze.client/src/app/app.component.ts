import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { Observable } from 'rxjs';

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, HttpClientModule],
  template: `
    <h1>Weather Forecast</h1>
    <div *ngIf="loading">Loading...</div>
    <ul *ngIf="!loading">
      <li *ngFor="let item of forecasts">
        <strong>{{ item.date }}</strong> —
        {{ item.summary }} —
        {{ item.temperatureC }}°C ({{ item.temperatureF }}°F)
      </li>
    </ul>
  `
})
export class AppComponent implements OnInit {
  forecasts: WeatherForecast[] = [];
  loading = true;

  constructor(private http: HttpClient) {}

ngOnInit(): void {
  this.http.get<WeatherForecast[]>('http://localhost:5041/weatherforecast').subscribe({
    next: (data) => {
      this.forecasts = data;
      this.loading = false;
    },
    error: (err) => {
      console.error('Error loading weather data', err);
      this.loading = false;
    }
  });
}

}
