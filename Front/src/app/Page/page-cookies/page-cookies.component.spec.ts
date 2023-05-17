import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PageCookiesComponent } from './page-cookies.component';

describe('PageCookiesComponent', () => {
  let component: PageCookiesComponent;
  let fixture: ComponentFixture<PageCookiesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PageCookiesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PageCookiesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
