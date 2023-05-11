import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BlocRessourcesComponent } from './bloc-ressources.component';

describe('BlocRessourcesComponent', () => {
  let component: BlocRessourcesComponent;
  let fixture: ComponentFixture<BlocRessourcesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BlocRessourcesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BlocRessourcesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
