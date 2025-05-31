import {Component, AfterViewInit, createComponent, EnvironmentInjector, inject} from '@angular/core';
import {MapPopupComponent} from '../map-popup/map-popup.component';

@Component({
  selector: 'app-map',
  imports: [],
  templateUrl: './map.component.html',
  styleUrl: './map.component.scss',
  standalone: true
})
export class MapComponent implements AfterViewInit {
  private environmentInjector = inject(EnvironmentInjector);

  private punkty = [
    { lat: 50.0619, lng: 19.9368, opis: 'Kraków1' },
    { lat: 50.0700, lng: 19.9369, opis: 'Kraków2' },
    { lat: 50.0500, lng: 19.9361, opis: 'Kraków3' },
    { lat: 50.0800, lng: 19.9500, opis: 'Kraków4' }
  ];

  mapExpanded = false;

  expandMap() {
    if (!this.mapExpanded) {
      this.mapExpanded = true;
      const mapElement = document.getElementById('map');
      if (mapElement) {
        mapElement.classList.add('expanded');
        setTimeout(() => {
          window.dispatchEvent(new Event('resize'));
        }, 300);
      }
    }
  }

  closeMap(event: Event) {
    event.stopPropagation();
    if (this.mapExpanded) {
      this.mapExpanded = false;
      const mapElement = document.getElementById('map');
      if (mapElement) {
        mapElement.classList.remove('expanded');
        setTimeout(() => {
          window.dispatchEvent(new Event('resize'));
        }, 300);
      }
    }
  }

  async ngAfterViewInit(): Promise<void> {
    const L = await import('leaflet');

    const myIcon = L.icon({
      iconUrl: 'assets/marker.png',
      iconSize: [32, 32],
      iconAnchor: [16, 32],
      popupAnchor: [0, -32]
    });

    const map = L.map('map').setView([50.0619, 19.9368], 12);
    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
      attribution: '&copy; OpenStreetMap contributors',
    }).addTo(map);

    this.punkty.forEach(punkt => {
      const popupContent = this.createPopupContent(punkt);
      L.marker([punkt.lat, punkt.lng], {icon: myIcon})
        .addTo(map)
        .bindPopup(popupContent);
    });
  }

  private createPopupContent(punkt: any): HTMLElement {
    const componentRef = createComponent(MapPopupComponent, {
      environmentInjector: this.environmentInjector
    });

    componentRef.setInput('lat', punkt.lat);
    componentRef.setInput('lng', punkt.lng);
    componentRef.setInput('opis', punkt.opis);

    componentRef.changeDetectorRef.detectChanges();

    return componentRef.location.nativeElement;
  }

}
