import {Component, OnInit, signal} from '@angular/core';
import { BurgerMenuComponent } from '../../burger-menu/burger-menu.component';
import {UserPointsService} from "../../services/user-points.service";

@Component({
  selector: 'app-header',
  imports: [BurgerMenuComponent],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent {

  constructor(public userPoints: UserPointsService) {}

}
