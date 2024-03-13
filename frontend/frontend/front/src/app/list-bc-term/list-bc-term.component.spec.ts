import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListBcTermComponent } from './list-bc-term.component';

describe('ListBcTermComponent', () => {
  let component: ListBcTermComponent;
  let fixture: ComponentFixture<ListBcTermComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ListBcTermComponent]
    });
    fixture = TestBed.createComponent(ListBcTermComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
