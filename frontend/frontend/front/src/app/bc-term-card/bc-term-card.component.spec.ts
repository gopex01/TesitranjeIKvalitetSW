import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BcTermCardComponent } from './bc-term-card.component';

describe('BcTermCardComponent', () => {
  let component: BcTermCardComponent;
  let fixture: ComponentFixture<BcTermCardComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [BcTermCardComponent]
    });
    fixture = TestBed.createComponent(BcTermCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
