import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { AbstractService } from '../../../commons/services/abstract-service';

import { User } from '../models/user.model';

@Injectable({
  providedIn: 'root',
})
export class UserService extends AbstractService {

  private serviceUri = 'api/me';

  constructor(private http: HttpClient) {
    super();
  }

  get(): Observable<User> {
    return this.http.get<User>(this.serviceUri)
      .pipe(catchError(this.handleError<User>('get')));
  }
}
