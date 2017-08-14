
import { EChartOption } from "echarts";
import { IStock } from "../models/stock";
import { round } from "../helpers/round";

export const stockChartOptions = (stocks: IStock[], ): EChartOption =>
  ({
    title: {
      text: 'Stock Price',
    },
    tooltip: {
      trigger: 'axis',
      axisPointer: {
        animation: false
      }
    },
    legend: {
      data: ['stock price'],
      x: 'right'
    },
    toolbox: undefined,
    dataZoom: [{
      show: true,
      realtime: true,
      start: 0,
      end: 100,
      xAxisIndex: [0, 1]
    }, {
      type: 'inside',
      realtime: true,
      xAxisIndex: [0, 1]
    }],
    grid: [{
      left: 40,
      right: 40,
    }, {
      left: 40,
      right: 40,
    }],
    xAxis: [{
      type: 'category',
      boundaryGap: false,
      axisLine: {
        onZero: true
      },
      data: stocks.map(x => x.date)
    }, {
      gridIndex: 1
    }],
    yAxis: [{
      type: 'value',
      max: 300,
      name: 'Price:',
      min: 0,
      interval: 25,
    }, {
      gridIndex: 1
    }],
    series: [{
      name: 'stock price',
      type: 'line',
      smooth: false,
      symbol: 'circle',
      symbolSize: 9,
      showSymbol: false,
      lineStyle: {
        normal: {
          width: 3,
        }
      },
      markLine: {
        lineStyle: {
          normal: {
            color: "#3fff00",
            type: 'solid',
            width: 4
          }
        },
        data: [[
          { coord: ['2017-01-10T17:00:00', 184.22] },
          { coord: ['2017-01-10T18:30:00', 184.22] }
        ]]
      },
      markPoint: {
        symbolOffset: [0, '-20%'],
        symbol: 'pin',
        symbolSize: [80, 55],
        data: [{
          type: 'max',
          name: 'Max',
          value: 'Max'
        }, {
          type: 'min',
          name: 'Min'
        }]
      },
      data: stocks.map(x => x.marketPrice).map(x => round(x, 2))
    }]
  });
