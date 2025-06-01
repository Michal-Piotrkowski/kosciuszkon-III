import { Component } from '@angular/core';
import {MapComponent} from '../../../../../shared/components/map/map.component';
import {SmallPanelComponent} from '../../../../shared/components/small-panel/small-panel.component';
import {FormsModule} from '@angular/forms';

@Component({
  selector: 'app-home',
  imports: [MapComponent, SmallPanelComponent, FormsModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {

  postalCode: string = '';

  searchLocation(event: Event): void {
    event.preventDefault();
    console.log('Wyszukiwanie po kodzie:', this.postalCode);
  }

  dummyUser = {
    nick: 'Kościuszkon Winner',
    points: 1920
  };
}
