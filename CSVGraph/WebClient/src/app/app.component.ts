import { IStock } from './shared/models/stock';
import { Component, OnInit } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';

import * as echarts from 'echarts';
import { stockChartOptions } from "./shared/echart_ts_chart_options/stock_chart_options";
import { StocksService } from "./services/stocks.service";
import { IStocks } from "./shared/models/stocks";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  constructor(private stocksService: StocksService) { }

  ngOnInit() {
  }
}
