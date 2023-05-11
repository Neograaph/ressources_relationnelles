import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BlocMesRelationsComponent } from './bloc-mes-relations.component';

describe('BlocMesRelationsComponent', () => {
  let component: BlocMesRelationsComponent;
  let fixture: ComponentFixture<BlocMesRelationsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BlocMesRelationsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BlocMesRelationsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
