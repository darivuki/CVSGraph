import { Component, OnInit, Input } from '@angular/core';
import { StocksService } from "../../services/stocks.service";
import { IStocks } from "../../shared/models/stocks";
import { stockChartOptions } from "../../shared/echart_ts_chart_options/stock_chart_options";

@Component({
  selector: 'chart',
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.css']
})
export class ChartComponent implements OnInit {

  options: Object = stockChartOptions();
  @Input()
  showChart: boolean;

  constructor(private stocksService: StocksService) { }

  ngOnInit() {
    this.initializeStockChart();
  }

  initializeStockChart = () => {
    this.stocksService
      .getStocks()
      .subscribe((data: IStocks) => {
        //if (!!data && data.stocks.length > 0) {
          this.options = stockChartOptions(data);
          this.showChart = true;
        //}
      });
  }

}
