import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BlocFooterComponent } from './bloc-footer.component';

describe('BlocFooterComponent', () => {
  let component: BlocFooterComponent;
  let fixture: ComponentFixture<BlocFooterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BlocFooterComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BlocFooterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
