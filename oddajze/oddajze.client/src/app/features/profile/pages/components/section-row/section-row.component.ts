import { Component, input } from '@angular/core';

@Component({
  selector: 'app-section-row',
  imports: [],
  templateUrl: './section-row.component.html',
  styleUrl: './section-row.component.scss'
})

export class SectionRowComponent {
  photoUrl = input();
  itemName = input.required<string>();
  numData = input();
}
