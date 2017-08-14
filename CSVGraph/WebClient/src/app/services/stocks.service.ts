import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IStock } from "../shared/models/stock";

@Injectable()
export class StocksService {

  constructor(private http: HttpClient) { }

  getStocks = () =>
    this.http.get<Array<IStock>>('http://localhost:60933/api/stocks')
}
