
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ToastrModule } from 'ngx-toastr';

import { MsalModule, MsalInterceptor, MsalAngularConfiguration, MSAL_CONFIG, MSAL_CONFIG_ANGULAR, MsalService } from '@azure/msal-angular';
import { Configuration } from 'msal';

import { AppComponent } from './app.component';

import { LayoutModule } from './layouts/layout.module';
import { AppRoutingModule } from './app-routing.module';
import { ComponentsModule } from './components/components.module';

import { UserModule } from './domain/frontend/users/users.module';

export const protectedResourceMap: [string, string[]][] = [
  ['api://497d4489-c9a6-4f96-9a3d-c81e6708cb9d', ['api://497d4489-c9a6-4f96-9a3d-c81e6708cb9d/access_as_user']],
  ['https://graph.microsoft.com/v1.0/me', ['user.read']]
];

function MSALConfigFactory(): Configuration {
  return {
    auth: {
      clientId: '497d4489-c9a6-4f96-9a3d-c81e6708cb9d',
      authority: 'https://login.microsoftonline.com/a0003aef-605a-4b34-a51c-613d9c5a8010/',
      validateAuthority: true,
      redirectUri: window.location.toString(),
      postLogoutRedirectUri: window.location.toString(),
      navigateToLoginRequestUrl: true,
    },
    cache: {
      cacheLocation: 'localStorage',
      storeAuthStateInCookie: false
    },
  };
}

function MSALAngularConfigFactory(): MsalAngularConfiguration {
  return {
    popUp: false,
    consentScopes: [
      'user.read',
      'openid',
      'profile',
      'api://497d4489-c9a6-4f96-9a3d-c81e6708cb9d/access_as_user'
    ],
    unprotectedResources: [],
    protectedResourceMap,
    extraQueryParameters: {}
  };
}

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
    MsalModule,

    AppRoutingModule,
    ComponentsModule,
    LayoutModule,

    UserModule
  ],

  declarations: [
    AppComponent
  ],

  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: MsalInterceptor,
      multi: true
    },

    {
      provide: MSAL_CONFIG,
      useFactory: MSALConfigFactory
    },

    {
      provide: MSAL_CONFIG_ANGULAR,
      useFactory: MSALAngularConfigFactory
    },

    MsalService
  ],

  bootstrap: [
    AppComponent
  ]
})
export class AppModule { }
