import { StockSubjectService } from './stock-subject.service';
import { FileUploadService } from './../file-upload.service';
import { Injectable } from '@angular/core';
import { Observable, BehaviorSubject } from 'rxjs/Rx';

@Injectable()
export class FileUploadSubjectService {

    // Observable sources
    private isUploadingFileAnnouncedSource = new BehaviorSubject(false);
    // Observable streams
    isUploadingFileAnnounced$ = this.isUploadingFileAnnouncedSource.asObservable();

    constructor(
      private fileUploadService: FileUploadService,
      private  stocksSubjectService: StockSubjectService) {
    }

    // Service commands
    announceIsUploadingFile(isUploadingFile: boolean) {
        // announce active sessions
        this.isUploadingFileAnnouncedSource.next(isUploadingFile);
    }

    announceUploadFile(formData: FormData) {
      this.isUploadingFileAnnouncedSource.next(true);

        Observable.fromPromise(this.fileUploadService.postUploadFile(formData))
          .subscribe(x => {
            this.isUploadingFileAnnouncedSource.next(false);
            this.stocksSubjectService.announceGetStocks();
          },
        error => {
          this.isUploadingFileAnnouncedSource.next(false);
          console.log(error)
        })
    }
}
