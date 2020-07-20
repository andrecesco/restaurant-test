import { Component, OnInit, OnDestroy, ViewChild } from '@angular/core';

import { Subscription } from 'rxjs';

import { subscriptionCleaner } from '../../../../commons/tools.utils';

import { OrderListComponent } from '../order-list/order-list.component';

@Component({
  selector: 'app-order-index',
  templateUrl: './order-index.component.html',
  styleUrls: ['./order-index.component.scss']
})
export class OrderIndexComponent implements OnInit, OnDestroy {
  @ViewChild(OrderListComponent) private listComponent: OrderListComponent;

  private orderSubscription: Subscription;

  constructor() {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
    subscriptionCleaner(this.orderSubscription);
  }

  onOrderCreate(event:any) {
    this.listComponent.onRefresh();
  }
}
