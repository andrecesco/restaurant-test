import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './layouts/home/home.component';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    runGuardsAndResolvers: 'always',
    component: HomeComponent
  }
];

export declare interface RouteInfo {
  path: string;
  title: string;
  rtlTitle: string;
  icon: string;
  class: string;
  external: boolean;
}

export const KnownRoutes: RouteInfo[] = [
  {
    path: '',
    title: 'Orders',
    rtlTitle: 'Orders',
    icon: 'fa fa-receipt',
    class: '',
    external: false
  },

  {
    path: '/api',
    title: 'Swagger API',
    rtlTitle: 'Swagger API',
    icon: 'fa fa-robot',
    class: '',
    external: true
  }
];

@NgModule({
  imports: [
    CommonModule,

    RouterModule.forRoot(routes, {
      onSameUrlNavigation: 'reload'
    })
  ],

  exports: [
    RouterModule
  ],

  providers: []
})
export class AppRoutingModule { }
