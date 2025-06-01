import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-small-panel',
  imports: [],
  templateUrl: './small-panel.component.html',
  styleUrl: './small-panel.component.scss'
})
export class SmallPanelComponent {
  @Input() titleLabel: string = '';
  @Input() text: string = '';
  @Input() iconClass?: string;
  @Input() buttonText?: string;
}
