import {
  Directive, ElementRef, Input, OnInit, HostBinding, OnChanges, OnDestroy
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

  constructor(private el: ElementRef) {
    console.log(el);
    this.chart = echarts.init(this.el.nativeElement, 'vintage');
  }

  ngOnChanges(changes) {
    if (this.options) {
      this.chart.setOption(this.options);
    }
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }

}
