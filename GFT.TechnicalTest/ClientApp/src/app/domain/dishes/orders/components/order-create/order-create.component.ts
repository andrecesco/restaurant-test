import { Component, OnDestroy, OnInit } from '@angular/core';

import { FormGroup, FormBuilder } from '@angular/forms';

import { Subscription } from 'rxjs';

import { subscriptionCleaner } from '../../../../commons/tools.utils';

import { OrderService } from '../../services/order.service';

import { FormOrder, CreateOptions, CreateValidations } from '../../models/form-order.model';
import { SelectOrder } from '../../models/select-order.model';

@Component({
  selector: 'app-order-create',
  templateUrl: './order-create.component.html',
  styleUrls: ['./order-create.component.scss']
})
export class OrderCreateComponent implements OnInit, OnDestroy {
  public orderForm: FormGroup;
  public loadingForm = false;
  public submitted = false;
  public orderResult = "";

  private dataSubscription: Subscription;

  constructor(private formBuilder: FormBuilder,
    private orderService: OrderService) {
  }

  get f() { return this.orderForm.controls; }

  ngOnInit() {
    this.orderForm = this.formBuilder.group(CreateOptions, CreateValidations);
  }

  ngOnDestroy() {
    subscriptionCleaner(this.dataSubscription);
  }

  doCancel() {
    this.orderForm.reset();
  }

  doSubmit() {
    this.submitted = true;

    if (!this.orderForm.invalid) {
      this.loadingForm = true;

      const formData = this.orderForm.value as FormOrder;
      subscriptionCleaner(this.dataSubscription);

      this.dataSubscription = this.orderService.create(formData)
        .subscribe(result => this.orderResult = result.data);
    }
  }
}
