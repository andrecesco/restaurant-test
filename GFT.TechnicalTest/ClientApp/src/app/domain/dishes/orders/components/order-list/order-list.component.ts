import { Component, OnInit, OnDestroy } from '@angular/core';

import { Subscription } from 'rxjs';

import { subscriptionCleaner } from '../../../../commons/tools.utils';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.scss']
})
export class OrderListComponent implements OnInit, OnDestroy {

  private dataSubscription: Subscription;

  constructor() {
  }

  ngOnInit() {
  }

  ngOnDestroy() {
    subscriptionCleaner(this.dataSubscription);
  }

  onRefresh() {
  }
}
