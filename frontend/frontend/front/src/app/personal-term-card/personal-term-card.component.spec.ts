import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PersonalTermCardComponent } from './personal-term-card.component';

describe('PersonalTermCardComponent', () => {
  let component: PersonalTermCardComponent;
  let fixture: ComponentFixture<PersonalTermCardComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PersonalTermCardComponent]
    });
    fixture = TestBed.createComponent(PersonalTermCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
