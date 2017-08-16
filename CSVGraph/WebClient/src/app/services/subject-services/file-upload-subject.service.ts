import { FileUploadService } from './../file-upload.service';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/BehaviorSubject'

@Injectable()
export class FileUploadSubjectService {

    constructor(private fileUploadService: FileUploadService) {
    }

    // Observable sources
    private shouldDisplayAnnouncedSource = new BehaviorSubject(false);

    // Observable streams
    shouldDisplayAnnounced$ = this.shouldDisplayAnnouncedSource.asObservable();

    // Service commands
    announceIsUploadingFile(isUploadingFile: boolean) {
        // announce active sessions
        this.shouldDisplayAnnouncedSource.next(isUploadingFile);
    }

    announceUploadingFile(){
      this.fileUploadService.uploadFile();
    }
}
