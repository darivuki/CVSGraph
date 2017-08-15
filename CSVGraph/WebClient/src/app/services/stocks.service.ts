import { IStocks } from './../shared/models/stocks';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class StocksService {

  constructor(private http: HttpClient) { }

  getStocks = (includeMostExpensiveHour: boolean = true) =>
    this.http.get<IStocks>(
      `http://localhost:60933/api/stocks?includeMostExpensiveHour=${includeMostExpensiveHour}`
    );
}
