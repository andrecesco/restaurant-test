import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';

import { MsalGuard } from '@azure/msal-angular';

import { HomeComponent } from './layouts/home/home.component';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    runGuardsAndResolvers: 'always',
    canActivate: [MsalGuard],
    component: HomeComponent,

    children: [
      {
        path: 'users',
        loadChildren: () => import('./domain/frontend/users/users.module').then(m => m.UserModule)
      }
    ]
  }
];

export declare interface RouteInfo {
  path: string;
  title: string;
  rtlTitle: string;
  icon: string;
  class: string;
}

export const KnownRoutes: RouteInfo[] = [
  {
    path: '/users',
    title: 'User',
    rtlTitle: 'User',
    icon: 'fa fa-user',
    class: ''
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
