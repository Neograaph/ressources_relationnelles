import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FavRessourceComponent } from './FavRessource.component';

describe('FavRessourceComponent', () => {
  let component: FavRessourceComponent;
  let fixture: ComponentFixture<FavRessourceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FavRessourceComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FavRessourceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
