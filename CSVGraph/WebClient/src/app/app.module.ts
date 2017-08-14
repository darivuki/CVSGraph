import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { EchartsTsChartDirective } from './directives/echarts-ts-chart.directive';

import { StocksService } from './services/stocks.service';

@NgModule({
  declarations: [
    AppComponent,
    EchartsTsChartDirective
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [StocksService],
  bootstrap: [AppComponent]
})
export class AppModule { }
