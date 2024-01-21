import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BcprofileComponent } from './bcprofile.component';

describe('BcprofileComponent', () => {
  let component: BcprofileComponent;
  let fixture: ComponentFixture<BcprofileComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [BcprofileComponent]
    });
    fixture = TestBed.createComponent(BcprofileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
