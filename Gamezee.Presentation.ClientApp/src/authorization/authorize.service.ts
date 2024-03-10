import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Register } from './models/register';
import { Observable } from 'rxjs';
import { JwtAuth } from './jwtToken';
import { environment } from '../environments/environment.development';
import { ApplicationPaths } from './authorization.constants';
import { Login } from './models/login';

@Injectable({
  providedIn: 'root'
})
export class AuthorizeService {

  constructor(private http: HttpClient) { }

  // public isAuthenticated(): Observable<boolean>{

  // }

  public register(user: Register): Observable<void> {
    return this.http.post<void>(environment.apiUrl + ApplicationPaths.Register, user);
  }

  public login(user: Login): Observable<JwtAuth> {
    return this.http.post<JwtAuth>(environment.apiUrl + ApplicationPaths.Login, user);
  }

}
