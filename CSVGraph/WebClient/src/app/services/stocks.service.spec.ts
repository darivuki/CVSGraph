import { TestBed, inject } from '@angular/core/testing';

import { StocksServiceService } from './stocks.service';

describe('StocksServiceService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [StocksServiceService]
    });
  });

  it('should be created', inject([StocksServiceService], (service: StocksServiceService) => {
    expect(service).toBeTruthy();
  }));
});
