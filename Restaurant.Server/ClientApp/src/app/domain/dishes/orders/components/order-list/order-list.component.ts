import { Component, OnInit, OnDestroy } from '@angular/core';

import { Subscription } from 'rxjs';

import { subscriptionCleaner } from '../../../../commons/tools.utils';

import { OrderService } from '../../services/order.service';

import { ItemOrder } from '../../models/item-order.model';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.scss']
})
export class OrderListComponent implements OnInit, OnDestroy {
  public data: ItemOrder[];
  public loaded: boolean;

  private dataSubscription: Subscription;

  constructor(private orderService: OrderService) {
    this.loaded = false;
  }

  ngOnInit() {
    this.onRefresh();
  }

  ngOnDestroy() {
    subscriptionCleaner(this.dataSubscription);
  }

  onRefresh() {
    subscriptionCleaner(this.dataSubscription);
    this.loaded = false;

    this.dataSubscription = this.orderService.getAll()
      .subscribe(response => {
        this.loaded = true;
        this.data = response;
      });
  }
}
