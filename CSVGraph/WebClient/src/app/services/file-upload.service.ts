import { webApiBaseURL } from './../shared/helpers/web-api-url';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class FileUploadService {

  constructor(private http: HttpClient) { }

  postUploadFile(formData: FormData) {
    return new Promise<any>((resolve, reject) => {
      this.http
          .post(webApiBaseURL("stocks/upload"), formData)
          .subscribe(x => {
            resolve(x);
          },
        error => {
          reject(error);
        });
    });

  }
}
