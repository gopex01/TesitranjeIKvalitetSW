import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BcDeleteComponent } from './bc-delete.component';

describe('BcDeleteComponent', () => {
  let component: BcDeleteComponent;
  let fixture: ComponentFixture<BcDeleteComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [BcDeleteComponent]
    });
    fixture = TestBed.createComponent(BcDeleteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
