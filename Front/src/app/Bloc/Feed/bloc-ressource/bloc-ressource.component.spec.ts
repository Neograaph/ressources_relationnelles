import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BlocRessourceComponent } from './bloc-ressource.component';

describe('BlocRessourceComponent', () => {
  let component: BlocRessourceComponent;
  let fixture: ComponentFixture<BlocRessourceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BlocRessourceComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BlocRessourceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
