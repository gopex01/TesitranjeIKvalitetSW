import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateTerminComponent } from './create-termin.component';

describe('CreateTerminComponent', () => {
  let component: CreateTerminComponent;
  let fixture: ComponentFixture<CreateTerminComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CreateTerminComponent]
    });
    fixture = TestBed.createComponent(CreateTerminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
