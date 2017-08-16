import { IStocks } from './../shared/models/stocks';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { webApiBaseURL } from "../shared/helpers/web-api-url";



@Injectable()
export class StocksService {

  constructor(private http: HttpClient) { }

  getStocks = (includeMostExpensiveHour: boolean = true) => // added default parameter here for simplicity
    this.http.get<IStocks>(webApiBaseURL(`stocks?includeMostExpensiveHour=${includeMostExpensiveHour}`));
}
