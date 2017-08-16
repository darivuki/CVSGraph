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
  @Input() showChart: boolean

  constructor(private el: ElementRef) {
    this.chart = echarts.init(this.el.nativeElement, 'vintage');
  }

  ngOnChanges(changes) {
      if (this.options && this.showChart === true) {
      this.chart.setOption(this.options);
    } else if (this.showChart === false) {
      this.chart.dispose();
    }
  }

  ngOnInit() {
  }

  ngOnDestroy() {
    debugger;
    this.chart.dispose();
  }

}
