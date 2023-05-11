import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PageVitrineComponent } from './page-vitrine.component';

describe('PageVitrineComponent', () => {
  let component: PageVitrineComponent;
  let fixture: ComponentFixture<PageVitrineComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PageVitrineComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PageVitrineComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
