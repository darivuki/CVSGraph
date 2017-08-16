import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';

import { StocksService } from './services/stocks.service';
import { FileUploadService } from './services/file-upload.service';
import { FileUploadSubjectService } from './services/subject-services/file-upload-subject.service';
import { StockSubjectService } from './services/subject-services/stock-subject.service';

import { FileUploadComponent } from './components/file-upload/file-upload.component';
import { ChartComponent } from './components/chart/chart.component';
import { EchartsTsChartDirective } from './directives/echarts-ts-chart.directive';


@NgModule({
  declarations: [
    AppComponent,
    EchartsTsChartDirective,
    FileUploadComponent,
    ChartComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [StocksService, FileUploadSubjectService, FileUploadService, StockSubjectService],
  bootstrap: [AppComponent]
})
export class AppModule { }
