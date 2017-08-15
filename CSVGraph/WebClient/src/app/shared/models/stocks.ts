import { IStock } from './stock'

export interface IStocks {
  stocks: Array<IStock>;
  mostExpensiveHour?: Array<IStock>;
}
