import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListBcDeleteComponent } from './list-bc-delete.component';

describe('ListBcDeleteComponent', () => {
  let component: ListBcDeleteComponent;
  let fixture: ComponentFixture<ListBcDeleteComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ListBcDeleteComponent]
    });
    fixture = TestBed.createComponent(ListBcDeleteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
