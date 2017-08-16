import { StockSubjectService } from './../../services/subject-services/stock-subject.service';
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
  options: Object = stockChartOptions(); // Initialize char without data
  isGettingStocksData: boolean = true;

  constructor(private stocksSubjectService: StockSubjectService) { }

  ngOnInit() {

    this.stocksSubjectService.isGettingstocksDataAnnounced$
      .skip(1)
      .subscribe(x => {
         this.isGettingStocksData = x;
      })

    this.stocksSubjectService.stocksDataAnnounced$
      .subscribe(data => {
        this.options = stockChartOptions(data);
      });

    this.stocksSubjectService.announceGetStocks();

  }
}
