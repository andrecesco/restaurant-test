
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ToastrModule } from 'ngx-toastr';

import { AppComponent } from './app.component';

import { LayoutModule } from './layouts/layout.module';
import { AppRoutingModule } from './app-routing.module';
import { ComponentsModule } from './components/components.module';

import { OrderModule } from './domain/dishes/orders/orders.module';

@NgModule({
  imports: [
    BrowserAnimationsModule,
    BrowserModule,
    CommonModule,
    FormsModule,
    HttpClientModule,
    RouterModule,

    NgbModule,
    ToastrModule.forRoot(),

    AppRoutingModule,
    ComponentsModule,
    LayoutModule,

    OrderModule
  ],

  declarations: [
    AppComponent
  ],

  bootstrap: [
    AppComponent
  ]
})
export class AppModule { }
