/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { MesesService } from './mes.service';

describe('Service: Mes', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [MesesService]
    });
  });

  it('should ...', inject([MesesService], (service: MesesService) => {
    expect(service).toBeTruthy();
  }));
});
