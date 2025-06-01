import {Component, OnInit, signal} from '@angular/core';
import {MapComponent} from '../../../../../shared/components/map/map.component';
import {SmallPanelComponent} from '../../../../shared/components/small-panel/small-panel.component';
import {FormsModule} from '@angular/forms';
import {Observable} from 'rxjs';
import {User} from '../../../../shared/models/user.models';
import {HttpService} from '../../../../shared/services/http.service';

@Component({
  selector: 'app-home',
  imports: [MapComponent, SmallPanelComponent, FormsModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent implements OnInit {

  postalCode: string = '';
  name = signal<string>('');
  constructor(private http: HttpService) {}

  searchLocation(event: Event): void {
    event.preventDefault();
    console.log('Wyszukiwanie po kodzie:', this.postalCode);
  }

  ngOnInit(): void {
    this.getLoggedUser().subscribe(loggedUser => {
      this.name = signal(loggedUser.firstName);
    })

  }
  getLoggedUser(): Observable<User> {
    return this.http.get('Users/me');
  }
}
