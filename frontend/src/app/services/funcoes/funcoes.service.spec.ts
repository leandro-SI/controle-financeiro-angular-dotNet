/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { FuncoesService } from './funcoes.service';

describe('Service: Funcoes', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [FuncoesService]
    });
  });

  it('should ...', inject([FuncoesService], (service: FuncoesService) => {
    expect(service).toBeTruthy();
  }));
});
