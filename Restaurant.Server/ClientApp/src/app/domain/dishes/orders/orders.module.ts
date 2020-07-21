import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { CommonsModule } from '../../commons/commons.module';

import { OrderService } from './services/order.service';

import { OrderListComponent } from './components/order-list/order-list.component';
import { OrderCreateComponent } from './components/order-create/order-create.component';
import { OrderIndexComponent } from './components/order-index/order-index.component';

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
    OrderCreateComponent,
    OrderIndexComponent
  ],

  exports: [
    OrderListComponent,
    OrderCreateComponent,
    OrderIndexComponent
  ],

  providers: [
    OrderService
  ],
})
export class OrderModule { }
