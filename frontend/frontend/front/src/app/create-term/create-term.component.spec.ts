import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateTermComponent } from './create-term.component';

describe('CreateTermComponent', () => {
  let component: CreateTermComponent;
  let fixture: ComponentFixture<CreateTermComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CreateTermComponent]
    });
    fixture = TestBed.createComponent(CreateTermComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
