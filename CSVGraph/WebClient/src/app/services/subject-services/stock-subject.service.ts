import { IStocks } from './../../shared/models/stocks';
import { BehaviorSubject } from 'rxjs';
import { StocksService } from './../stocks.service';
import { Injectable } from '@angular/core';

@Injectable()
export class StockSubjectService {

  // Observable sources
  private stocksDataAnnouncedSource = new BehaviorSubject<IStocks>(undefined);
  private isGettingStocksDataAnnouncedSource = new BehaviorSubject(false);
  // Observable streams
  stocksDataAnnounced$ = this.stocksDataAnnouncedSource.asObservable();
  isGettingstocksDataAnnounced$ = this.isGettingStocksDataAnnouncedSource.asObservable();

  constructor(private stocksService: StocksService) { }

  announceGetStocks() {
    this.isGettingStocksDataAnnouncedSource.next(true);
    this.stocksService
      .getStocks()
      .subscribe((data: IStocks) => {
        this.isGettingStocksDataAnnouncedSource.next(false);
        this.stocksDataAnnouncedSource.next(data);
      },
    error => {
      this.isGettingStocksDataAnnouncedSource.next(false);
      console.log(error);
    });
  }

}
