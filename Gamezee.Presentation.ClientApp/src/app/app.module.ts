import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';

import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AuthorizeInterceptor } from '../authorization/authorize.interceptor';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthorizationModule } from '../authorization/authorization.module';
import { FormsModule } from '@angular/forms';
import { JwtModule } from '@auth0/angular-jwt';
import { JwtAuth } from '../authorization/jwtToken';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AuthorizationModule,
    JwtModule.forRoot({
      config:{
        tokenGetter: () => (JSON.parse(localStorage.getItem('jwt') ?? '') as JwtAuth)?.accessToken
      }
    }),
    NgbModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true },
    provideClientHydration()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
