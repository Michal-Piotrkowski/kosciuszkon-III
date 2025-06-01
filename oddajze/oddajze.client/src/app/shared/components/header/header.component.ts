import {Component, OnInit, signal} from '@angular/core';
import { BurgerMenuComponent } from '../../burger-menu/burger-menu.component';
import {HttpService} from "../../services/http.service";
import {Observable} from "rxjs";
import {RankingUser} from "../../models/ranking-user.model";
import {User} from "../../models/user.models";

@Component({
  selector: 'app-header',
  imports: [BurgerMenuComponent],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss',
  providers: [HttpService]
})
export class HeaderComponent implements OnInit {

  nick = signal<string>('');
  points = signal<number>(0);

  constructor(private http: HttpService) {}
  ngOnInit(): void {
      this.getLoggedUser().subscribe(loggedUser => {
        this.nick = signal(loggedUser.username);
        this.points = signal(loggedUser.totalPoints);
      })

  }
  getLoggedUser(): Observable<User> {
    return this.http.get('Users/me');
  }

}
