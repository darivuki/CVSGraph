import { TestBed, inject } from '@angular/core/testing';

import { FileUploadSubjectService } from './file-upload-subject.service';

describe('FileUploadSubjectService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [FileUploadSubjectService]
    });
  });

  it('should be created', inject([FileUploadSubjectService], (service: FileUploadSubjectService) => {
    expect(service).toBeTruthy();
  }));
});
