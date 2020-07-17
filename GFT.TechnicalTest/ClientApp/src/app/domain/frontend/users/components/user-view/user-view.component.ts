import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { Subscription } from 'rxjs';

import { subscriptionCleaner, routerRefresh } from '../../../../commons/tools.utils';

import { User } from '../../models/user.model';

@Component({
  selector: 'app-user-view',
  templateUrl: './user-view.component.html',
  styleUrls: ['./user-view.component.scss']
})
export class UserViewComponent implements OnInit, OnDestroy {
  data: User;

  private dataSubscription: Subscription;

  constructor(private router: Router,
              private activatedRoute: ActivatedRoute) {
  }

  ngOnInit() {
    subscriptionCleaner(this.dataSubscription);

    this.dataSubscription = this.activatedRoute.data
      .subscribe(result => this.data = result.user);
  }

  ngOnDestroy() {
    subscriptionCleaner(this.dataSubscription);
  }

  onRefresh() {
    routerRefresh(this.router);
  }
}
