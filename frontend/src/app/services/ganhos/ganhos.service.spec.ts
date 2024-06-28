/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { GanhosService } from './ganhos.service';

describe('Service: Ganhos', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [GanhosService]
    });
  });

  it('should ...', inject([GanhosService], (service: GanhosService) => {
    expect(service).toBeTruthy();
  }));
});
