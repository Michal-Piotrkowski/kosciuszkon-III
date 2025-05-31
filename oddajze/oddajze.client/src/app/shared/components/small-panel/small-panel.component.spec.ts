import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SmallPanelComponent } from './small-panel.component';

describe('SmallPanelComponent', () => {
  let component: SmallPanelComponent;
  let fixture: ComponentFixture<SmallPanelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SmallPanelComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SmallPanelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
