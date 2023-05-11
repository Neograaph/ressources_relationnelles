import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FiltreRechercheComponent } from './FiltreRecherche.component';

describe('FiltreRechercheComponent', () => {
  let component: FiltreRechercheComponent;
  let fixture: ComponentFixture<FiltreRechercheComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FiltreRechercheComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FiltreRechercheComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
