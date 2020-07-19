import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { AbstractService } from '../../../commons/services/abstract-service';

import { CreateOrder } from '../models/create-order.model';
import { FormOrder } from '../models/form-order.model';
import { SelectOrder } from '../models/select-order.model';

@Injectable({
  providedIn: 'root',
})
export class OrderService extends AbstractService {

  private serviceUri = 'api/orders';

  constructor(private http: HttpClient) {
    super();
  }

  create(model: FormOrder): Observable<SelectOrder> {
    const data = this.parseOrder(model);

    return this.http.post<SelectOrder>(this.serviceUri, data)
      .pipe(catchError(this.handleError<SelectOrder>('create')));
  }

  private parseOrder(model: FormOrder): CreateOrder {
    const [period, ...dishes] = model.order.split(',').map(i => i.trim());

    const result = new CreateOrder();
    result.period = period;
    result.dishes = dishes.map(dish => parseInt(dish, 10));

    return result;
  }
}
