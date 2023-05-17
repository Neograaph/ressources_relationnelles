import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PagePlanSiteComponent } from './page-plan-site.component';

describe('PagePlanSiteComponent', () => {
  let component: PagePlanSiteComponent;
  let fixture: ComponentFixture<PagePlanSiteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PagePlanSiteComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PagePlanSiteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
