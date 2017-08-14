import { IStock } from './shared/models/stock';
import { Component, OnInit } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';

import * as echarts from 'echarts';
import { stockChartOptions } from "./shared/echart_ts_chart_options/stock_chart_options";
import { StocksService } from "./services/stocks.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  options: Object;
  private minStocks: IStock[];
  private maxStocks: IStock[];

  constructor(private stocksService: StocksService) {

  }

  ngOnInit() {
    this.stocksService.getStocks()
      .subscribe(result => {
        console.log(result);
        this.options = stockChartOptions(result);
      });

  }

  formatStocks = (stock: IStock) =>
    [Date.parse(stock.date), stock.marketPrice];
  // stocks.map(stock => [Date.parse(stock.date), stock.marketPrice])

  findMinMaxStockPrice = (stocks: IStock[]) => {
    let maxValues = new Array<IStock>();
    let minValues = new Array<IStock>();

    const prices = stocks.map(x => x.marketPrice)
    const maxValue = Math.max(...prices);
    const minValue = Math.min(...prices);

    maxValues = stocks.filter(x => x.marketPrice === maxValue);
    minValues = stocks.filter(x => x.marketPrice === minValue);

    return [minValues, maxValues];
  }
}
