import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListBordercrossComponent } from './list-bordercross.component';

describe('ListBordercrossComponent', () => {
  let component: ListBordercrossComponent;
  let fixture: ComponentFixture<ListBordercrossComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ListBordercrossComponent]
    });
    fixture = TestBed.createComponent(ListBordercrossComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
