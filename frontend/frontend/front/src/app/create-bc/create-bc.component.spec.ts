import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateBCComponent } from './create-bc.component';

describe('CreateBCComponent', () => {
  let component: CreateBCComponent;
  let fixture: ComponentFixture<CreateBCComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CreateBCComponent]
    });
    fixture = TestBed.createComponent(CreateBCComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
