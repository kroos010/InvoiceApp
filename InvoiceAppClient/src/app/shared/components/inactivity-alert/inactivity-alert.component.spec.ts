import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InactivityAlertComponent } from './inactivity-alert.component';

describe('InactivityAlertComponent', () => {
  let component: InactivityAlertComponent;
  let fixture: ComponentFixture<InactivityAlertComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InactivityAlertComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InactivityAlertComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
