import { Component } from '@angular/core';
import { BurgerMenuComponent } from '../../burger-menu/burger-menu.component';

@Component({
  selector: 'app-header',
  imports: [BurgerMenuComponent],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent {
  dummyUser = {
    nick: 'John Doe',
    points: 1920
  }

  dummyMenu = false;
}
