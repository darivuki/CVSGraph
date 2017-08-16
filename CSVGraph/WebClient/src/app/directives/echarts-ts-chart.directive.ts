import {
  Directive, ElementRef, Input, OnInit,
  HostBinding, OnChanges, OnDestroy, Renderer2
} from '@angular/core';

import * as echarts from 'echarts';
import ECharts = echarts.ECharts;
import EChartOption = echarts.EChartOption;

@Directive({
  selector: '[eChartsTsChart]'
})
export class EchartsTsChartDirective implements OnInit, OnChanges, OnDestroy {

  private chart: ECharts;

  @Input() options: EChartOption;
  @Input() isGettingStocksData: boolean;

  constructor(private el: ElementRef) {
    this.chart = echarts.init(this.el.nativeElement, 'vintage');
  }

  ngOnChanges(changes) {
    debugger;
    if (this.isGettingStocksData) {
      this.chart.showLoading();
    } else if (this.options) {
      this.chart.hideLoading();
      this.chart.setOption(this.options);
    }
  }

  ngOnInit() {
  }

  ngOnDestroy() {
    this.chart.dispose();
  }

}
