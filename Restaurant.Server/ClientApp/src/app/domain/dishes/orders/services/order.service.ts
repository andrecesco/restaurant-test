import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';

import { AbstractService } from '../../../commons/services/abstract-service';

import { CreateOrder } from '../models/create-order.model';
import { FormOrder } from '../models/form-order.model';
import { SelectOrder } from '../models/select-order.model';
import { ItemOrder } from '../models/item-order.model';

@Injectable({
  providedIn: 'root',
})
export class OrderService extends AbstractService {

  private serviceUri = 'api/orders';

  private orderHistory: ItemOrder[];

  constructor(private http: HttpClient) {
    super();

    this.orderHistory = [];
  }

  create(model: FormOrder): Observable<SelectOrder> {
    const data = this.parseOrder(model);

    return this.http.post<SelectOrder>(this.serviceUri, data)
      .pipe(catchError(this.handleError<SelectOrder>('create')),
        map((result: SelectOrder) => this.persistHistory(model, result)));
  }

  getAll(): Observable<ItemOrder[]> {
    return of(this.orderHistory);
  }

  private parseOrder(model: FormOrder): CreateOrder {
    const [period, ...dishes] = model.order.split(',').map(i => i.trim());

    const result: CreateOrder = {
      period: period,
      dishes: dishes.map(dish => parseInt(dish, 10))
    };

    return result;
  }

  private persistHistory(modelInput: FormOrder, modelOutput: SelectOrder): SelectOrder {
    const historyItem: ItemOrder = {
      input: modelInput.order,
      output: modelOutput.data
    };

    this.orderHistory.push(historyItem);
    return modelOutput;
  }
}
