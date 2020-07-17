import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { Routes, RouterModule } from '@angular/router';

import { MsalGuard } from '@azure/msal-angular';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { CommonsModule } from '../../commons/commons.module';

import { UserService } from './services/user.service';

import { UserResolver } from './resolvers/user.resolver';

import { UserViewComponent } from './components/user-view/user-view.component';

export const routes: Routes = [
  {
    path: 'users',
    pathMatch: 'full',
    runGuardsAndResolvers: 'always',
    canActivate: [MsalGuard],
    component: UserViewComponent,
    resolve: {
      user: UserResolver
    }
  },

  {
    path: 'me',
    pathMatch: 'full',
    runGuardsAndResolvers: 'always',
    canActivate: [MsalGuard],
    component: UserViewComponent,
    resolve: {
      user: UserResolver
    }
  }
];

@NgModule({
  imports: [
    CommonModule,
    HttpClientModule,
    RouterModule.forChild(routes),

    NgbModule,

    CommonsModule
  ],

  declarations: [
    UserViewComponent
  ],

  exports: [
    RouterModule,

    UserViewComponent
  ],

  providers: [
    UserService,

    UserResolver
  ],
})
export class UserModule { }
