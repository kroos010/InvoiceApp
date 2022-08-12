import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OpenInvoicesComponent } from './open-invoices.component';

describe('OpenInvoicesComponent', () => {
  let component: OpenInvoicesComponent;
  let fixture: ComponentFixture<OpenInvoicesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OpenInvoicesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OpenInvoicesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
