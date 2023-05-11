import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BlocInscriptionComponent } from './bloc-inscription.component';

describe('BlocInscriptionComponent', () => {
  let component: BlocInscriptionComponent;
  let fixture: ComponentFixture<BlocInscriptionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BlocInscriptionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BlocInscriptionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
