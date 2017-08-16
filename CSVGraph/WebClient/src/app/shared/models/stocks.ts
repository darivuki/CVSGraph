import { IStock } from './stock'

export interface IStocks {
  stocks: Array<IStock>;
  mostExpensiveHour?: Array<IStock>;
  lowestStock: IStock;
  highestStock: IStock;
}

export class StocksNull implements IStocks {
  public stocks: Array<IStock> = new Array<IStock>();
  public mostExpensiveHour?: Array<IStock> = new Array<IStock>();
  public lowestStock: IStock = ({ date: undefined, marketPrice: undefined  });
  public highestStock: IStock = ({ date: undefined, marketPrice: undefined  });
}
