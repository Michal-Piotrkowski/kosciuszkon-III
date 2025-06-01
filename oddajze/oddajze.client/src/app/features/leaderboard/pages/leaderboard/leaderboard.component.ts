import { Component } from '@angular/core';
import { SmallPanelComponent} from '../../../../shared/components/small-panel/small-panel.component';

@Component({
  selector: 'app-leaderboard',
  imports: [
    SmallPanelComponent,
  ],
  templateUrl: './leaderboard.component.html',
  styleUrl: './leaderboard.component.scss'
})
export class LeaderboardComponent {

}
