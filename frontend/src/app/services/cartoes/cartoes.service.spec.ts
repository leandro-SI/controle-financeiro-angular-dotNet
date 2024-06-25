/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { CartoesService } from './cartoes.service';

describe('Service: Cartoes', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CartoesService]
    });
  });

  it('should ...', inject([CartoesService], (service: CartoesService) => {
    expect(service).toBeTruthy();
  }));
});
