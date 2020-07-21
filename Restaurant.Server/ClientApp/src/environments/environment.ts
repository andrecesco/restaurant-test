// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

const scopeDefinition: Map<string, string[]> = new Map<string, string[]>();
scopeDefinition.set('api://497d4489-c9a6-4f96-9a3d-c81e6708cb9d', ['api://497d4489-c9a6-4f96-9a3d-c81e6708cb9d/access_as_user']);
scopeDefinition.set('https://graph.microsoft.com/v1.0/me', ['user.read']);

export const environment = {
  production: false,

  auth: {
    clientId: '497d4489-c9a6-4f96-9a3d-c81e6708cb9d', // This is your client ID
    authority: 'https://login.microsoftonline.com/a0003aef-605a-4b34-a51c-613d9c5a8010', // This is your tenant info
    redirectUri: 'https://localhost:44334/' // This is your redirect URI
  },

  scopes: scopeDefinition
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
