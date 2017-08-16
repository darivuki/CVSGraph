import { webApiBaseURL } from './../../shared/helpers/web-api-url';
import { HttpClient } from '@angular/common/http';
import { Component, ElementRef, Input, ViewChild } from '@angular/core';

@Component({
  selector: 'file-upload',
  templateUrl: './file-upload.component.html',
  styleUrls: ['./file-upload.component.css']
})
export class FileUploadComponent {
    @Input() multiple: boolean = false;
    @ViewChild('fileInput') inputEl: ElementRef;

    constructor(private http: HttpClient) {}

    upload($event) {
        let inputEl: HTMLInputElement = this.inputEl.nativeElement;
        let fileCount: number = inputEl.files.length;
        let formData = new FormData();
        formData.append('file', inputEl.files[0]);

            this.http
                .post(webApiBaseURL("stocks/upload"), formData)
                .subscribe(x => {
                  console.log(x);
                });
        }
}
