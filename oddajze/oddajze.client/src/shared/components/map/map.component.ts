import {Component, AfterViewInit, createComponent, EnvironmentInjector, inject, OnInit, Input} from '@angular/core';
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
  @Input() postalCode: string | null = null;

  points: CollectionPoint[] = [];
  private map: any;
  constructor(private collectionPointService: CollectionPointService) {}

  ngOnInit() {
    this.collectionPointService.getAllPoints().subscribe({
      next: (data) => {
        this.points = data;
        this.points.forEach(point => {
          console.log(`Punkt: lat=${point.latitude}, lng=${point.longitude}, opis=${point.description}`);

        });
        if (this.map) { // jeśli mapa jest już zainicjalizowana
          this.addMarkers(); // dodaj markery
        }
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

    this.map = L.map('map', {
      zoomControl: false
    }).setView([50.0619, 19.9368], 12);
    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
      attribution: '&copy; OpenStreetMap contributors',
    }).addTo(this.map);
    L.control.zoom({
      position: 'bottomleft'
    }).addTo(this.map);


    if (this.points.length > 0) { // jeśli punkty już są pobrane
      this.addMarkers();
    }

  }

  private addMarkers(): void {
    const L = (window as any).L;
    const myIcon = L.icon({
      iconUrl: 'assets/marker.png',
      iconSize: [32, 32],
      iconAnchor: [16, 32],
      popupAnchor: [0, -32]
    });

    this.points.forEach(punkt => {
      const popupContent = this.createPopupContent(punkt);
      L.marker([punkt.latitude, punkt.longitude], {icon: myIcon})
        .addTo(this.map)
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


  ngOnChanges() {
    if (this.postalCode) {
      // tutaj możesz odpalić zoom lub inne akcje na mapie
      this.zoomToPostalCode(this.postalCode);
    }
  }

  async zoomToPostalCode(kod: string) {
    if (!kod) return;
    const url = `https://nominatim.openstreetmap.org/search?format=json&country=Poland&postalcode=${encodeURIComponent(kod)}&limit=1`;
    try {
      const response = await fetch(url, {
        headers: {
          'Accept-Language': 'pl'  // żądanie po polsku
        }
      });
      const data = await response.json();
      if (data.length > 0) {
        const lat = parseFloat(data[0].lat);
        const lon = parseFloat(data[0].lon);
        this.map.setView([lat, lon], 12); // zoom na 14, możesz zmienić
      } else {
        console.warn('Nie znaleziono lokalizacji dla tego kodu pocztowego');
      }
    } catch (error) {
      console.error('Błąd podczas pobierania lokalizacji:', error);
    }
  }

}
