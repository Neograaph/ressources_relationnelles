import { TestBed } from '@angular/core/testing';

import { ActionsTypeService } from './actions-type.service';

describe('ActionsTypeService', () => {
  let service: ActionsTypeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ActionsTypeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
