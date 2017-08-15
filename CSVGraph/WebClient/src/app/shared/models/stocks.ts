import { IStock } from './stock'

export interface IStocks {
  stocks: Array<IStock>;
  mostExpensiveHour?: Array<IStock>;
}

export class StocksNull implements IStocks {
  public stocks: Array<IStock> = new Array<IStock>();
  public mostExpensiveHour?: Array<IStock> = new Array<IStock>();
}
