import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SectionRowComponent } from './section-row.component';

describe('SectionRowComponent', () => {
  let component: SectionRowComponent;
  let fixture: ComponentFixture<SectionRowComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SectionRowComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SectionRowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
