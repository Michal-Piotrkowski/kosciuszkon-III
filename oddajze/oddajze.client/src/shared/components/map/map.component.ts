import {Component, AfterViewInit, createComponent, EnvironmentInjector, inject, OnInit} from '@angular/core';
import {MapPopupComponent} from '../map-popup/map-popup.component';
import {CollectionPoint} from "../../../app/shared/models/collection-point.model";
import {CollectionPointService} from "../../../app/shared/services/collection-point.service";

@Component({
  selector: 'app-map',
  imports: [],
  templateUrl: './map.component.html',
  styleUrl: './map.component.scss',
  standalone: true
})
export class MapComponent implements AfterViewInit, OnInit {
  private environmentInjector = inject(EnvironmentInjector);

  points: CollectionPoint[] = [];

  constructor(private collectionPointService: CollectionPointService) {}

  ngOnInit() {
    this.collectionPointService.getAllPoints().subscribe({
      next: (data) => {
        this.points = data;
        this.points.forEach(point => {
          console.log(`Punkt: lat=${point.latitude}, lng=${point.longitude}, opis=${point.description}`);
        });
      },
      error: (error) => console.error('Błąd podczas pobierania punktów:', error)
    });
  }


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

    this.points.forEach(punkt => {
      const popupContent = this.createPopupContent(punkt);
      L.marker([punkt.latitude, punkt.longitude], {icon: myIcon})
        .addTo(map)
        .bindPopup(popupContent);
    });
  }

  private createPopupContent(punkt: any): HTMLElement {
    const componentRef = createComponent(MapPopupComponent, {
      environmentInjector: this.environmentInjector
    });

    componentRef.setInput('lat', punkt.latitude);
    componentRef.setInput('lng', punkt.longitude);
    componentRef.setInput('opis', punkt.name);

    componentRef.changeDetectorRef.detectChanges();

    return componentRef.location.nativeElement;
  }

}
