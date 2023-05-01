import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TfaSetupComponent } from './tfa-setup.component';

describe('TfaSetupComponent', () => {
  let component: TfaSetupComponent;
  let fixture: ComponentFixture<TfaSetupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TfaSetupComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TfaSetupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
