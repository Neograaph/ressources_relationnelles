import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MesRessourcesComponent } from './mes-ressources.component';

describe('MesRessourcesComponent', () => {
  let component: MesRessourcesComponent;
  let fixture: ComponentFixture<MesRessourcesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MesRessourcesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MesRessourcesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
