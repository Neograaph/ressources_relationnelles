import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BlocConnexionComponent } from './bloc-connexion.component';

describe('BlocConnexionComponent', () => {
  let component: BlocConnexionComponent;
  let fixture: ComponentFixture<BlocConnexionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BlocConnexionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BlocConnexionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
