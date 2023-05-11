import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PostRessourceComponent } from './PostRessource.component';

describe('PostRessourceComponent', () => {
  let component: PostRessourceComponent;
  let fixture: ComponentFixture<PostRessourceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PostRessourceComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PostRessourceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
