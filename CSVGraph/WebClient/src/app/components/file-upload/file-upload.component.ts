import { Subscription } from 'rxjs/Subscription';
import { FileUploadSubjectService } from './../../services/subject-services/file-upload-subject.service';
import { webApiBaseURL } from './../../shared/helpers/web-api-url';
import { HttpClient } from '@angular/common/http';
import { Component, ElementRef, Input, ViewChild, OnInit } from '@angular/core';

@Component({
  selector: 'file-upload',
  templateUrl: './file-upload.component.html',
  styleUrls: ['./file-upload.component.css']
})
export class FileUploadComponent implements OnInit {
    @Input() multiple: boolean = false;
    @ViewChild('fileInput') inputEl: ElementRef;

    private isUploadingFile: boolean = false;
    private shouldDisplayLoaderAnnouncedSubscription: Subscription;

    constructor(
      private http: HttpClient,
      private fileUploadSubjectService: FileUploadSubjectService
    ) {}

    ngOnInit() {
      this.shouldDisplayLoaderAnnouncedSubscription =
        this.fileUploadSubjectService
            .isUploadingFileAnnounced$
            .subscribe(x => {
              this.isUploadingFile = x;
            });
    }

    async upload($event) {

      let formData = new FormData()
      formData.append('file', this.inputEl.nativeElement.files[0]);

      await this.fileUploadSubjectService.announceUploadFile(formData);
    }
}
