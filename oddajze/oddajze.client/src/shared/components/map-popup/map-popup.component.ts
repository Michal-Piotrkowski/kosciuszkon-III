import {Component, Input} from '@angular/core';

@Component({
  selector: 'app-map-popup',
  imports: [],
  templateUrl: './map-popup.component.html',
  styleUrl: './map-popup.component.scss',
  standalone: true
})
export class MapPopupComponent {

  @Input() lat!: number;
  @Input() lng!: number;
  @Input() opis!: string;

  openGoogleMaps(): void {
    const url = `https://www.google.com/maps?q=${this.lat},${this.lng}`;
    window.open(url, '_blank');
  }

}
