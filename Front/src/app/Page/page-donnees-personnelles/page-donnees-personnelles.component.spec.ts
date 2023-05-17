import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PageDonneesPersonnellesComponent } from './page-donnees-personnelles.component';

describe('PageDonneesPersonnellesComponent', () => {
  let component: PageDonneesPersonnellesComponent;
  let fixture: ComponentFixture<PageDonneesPersonnellesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PageDonneesPersonnellesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PageDonneesPersonnellesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
