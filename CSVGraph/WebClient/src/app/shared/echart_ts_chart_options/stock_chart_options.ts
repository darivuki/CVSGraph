
import { EChartOption } from "echarts";
import { round } from "../helpers/round";
import { IStocks, StocksNull } from "../models/stocks";
import { IStock } from "../models/stock";

const getMinMaxCoord = (data: IStocks) => {
  if (data.lowestStock === null || data.highestStock === null) {
    return undefined;
  }
  return [
          { coord: [data.lowestStock.date, data.lowestStock.marketPrice] },
          { coord: [data.highestStock.date, data.highestStock.marketPrice] }
      ];
}

const getMostExpensivePeriodCoord = (data: IStocks = undefined) => {
  return data.mostExpensiveHour.length > 0 ? [[
          {
            symbol: 'diamond',
            coord: [data.mostExpensiveHour[0].date, data.mostExpensiveHour[0].marketPrice] },
          {
            symbol: 'diamond',
            coord: [data.mostExpensiveHour[data.mostExpensiveHour.length - 1].date, data.mostExpensiveHour[data.mostExpensiveHour.length - 1].marketPrice] }
        ]]
        : undefined
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
      max: 500,
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
            width: 1,
            type: 'solid',
          }
      },
      markLine: {
        symbolSize: 20,
        lineStyle: {
          normal: {
            color: "#293C55",
            type: 'solid',
            width: 6
          }
        },
        data: getMostExpensivePeriodCoord(data)
      },
      markPoint: {
        symbolOffset: [0, '-20%'],
        symbol: 'pin',
        symbolSize: [80, 55],
        data: getMinMaxCoord(data)
      },
      data: data.stocks.map(x => x.marketPrice).map(x => round(x, 2))
    }]
  })

}
