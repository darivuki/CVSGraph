import { TestBed, inject } from '@angular/core/testing';

import { StockSubjectService } from './stock-subject.service';

describe('StockSubjectService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [StockSubjectService]
    });
  });

  it('should be created', inject([StockSubjectService], (service: StockSubjectService) => {
    expect(service).toBeTruthy();
  }));
});
