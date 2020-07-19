import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { CommonsModule } from '../../commons/commons.module';

import { OrderService } from './services/order.service';

import { OrderListComponent } from './components/order-list/order-list.component';

import { OrderCreateComponent } from './components/order-create/order-create.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,

    NgbModule,

    CommonsModule
  ],

  declarations: [
    OrderListComponent,
    OrderCreateComponent
  ],

  exports: [
    OrderListComponent,
    OrderCreateComponent
  ],

  providers: [
    OrderService
  ],
})
export class OrderModule { }
