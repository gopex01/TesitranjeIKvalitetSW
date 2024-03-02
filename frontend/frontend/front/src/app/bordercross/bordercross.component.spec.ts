import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BordercrossComponent } from './bordercross.component';

describe('BordercrossComponent', () => {
  let component: BordercrossComponent;
  let fixture: ComponentFixture<BordercrossComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [BordercrossComponent]
    });
    fixture = TestBed.createComponent(BordercrossComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
