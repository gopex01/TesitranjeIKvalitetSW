import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BcProfileComponent } from './bc-profile.component';

describe('BcProfileComponent', () => {
  let component: BcProfileComponent;
  let fixture: ComponentFixture<BcProfileComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [BcProfileComponent]
    });
    fixture = TestBed.createComponent(BcProfileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
