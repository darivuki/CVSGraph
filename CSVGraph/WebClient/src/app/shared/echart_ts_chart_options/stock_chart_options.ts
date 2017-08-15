
import { EChartOption } from "echarts";
import { round } from "../helpers/round";
import { IStocks, StocksNull } from "../models/stocks";
import { IStock } from "../models/stock";

const getMostExpensivePeriodCoord = (data: IStocks = undefined) => {
debugger;
  return data.mostExpensiveHour.length > 0 ? [[
          { coord: [data.mostExpensiveHour[0].date, data.mostExpensiveHour[0].marketPrice] },
          { coord: [data.mostExpensiveHour[data.mostExpensiveHour.length - 1].date, data.mostExpensiveHour[data.mostExpensiveHour.length - 1].marketPrice] }
        ]]
        : [[
          { coord: undefined },
          { coord: undefined }
         ]]
}

export const stockChartOptions = (data: IStocks = new StocksNull()): EChartOption => {

  return ({
    title: {
      text: 'Stock Price (min, max, most expensive hour)',
    },
    tooltip: {
      trigger: 'axis',
      axisPointer: {
        animation: false
      }
    },
    legend: {
      data: [{
        name: 'stock price',
        icon: 'circle',
      }],
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
      data: data.stocks.map(x => x.date)
    }, {
      gridIndex: 1
    }],
    yAxis: [{
      type: 'value',
      max: 250,
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
            shadowColor: 'rgba(0,0,0,0.4)',
            shadowBlur: 5,
            shadowOffsetY: 10,
            type: 'dotted',
          }
      },
      markLine: {
        lineStyle: {
          normal: {
            color: "#293C55",
            type: 'solid',
            width: 4
          }
        },
        // data: [[
        //   { coord: [data.mostExpensiveHour[0].date, data.mostExpensiveHour[0].marketPrice] },
        //   { coord: [data.mostExpensiveHour[data.mostExpensiveHour.length - 1].date, data.mostExpensiveHour[data.mostExpensiveHour.length - 1].marketPrice] }
        // ]]
        data: getMostExpensivePeriodCoord(data)
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
      data: data.stocks.map(x => x.marketPrice).map(x => round(x, 2))
    }]
  })

}
