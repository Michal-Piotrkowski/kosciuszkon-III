import { Component } from '@angular/core';
import {MapComponent} from '../../../../../shared/components/map/map.component';
import {SmallPanelComponent} from '../../../../shared/components/small-panel/small-panel.component';

@Component({
  selector: 'app-home',
  imports: [MapComponent, SmallPanelComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {

  dummyUser = {
    nick: 'Kościuszkon Winner',
    points: 1920
  };
}
