import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { JwtAuth } from "./jwtToken";

@Injectable({
    providedIn: 'root'
})
export class AuthorizeInterceptor implements HttpInterceptor {
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        const jwt = localStorage.getItem('jwt');
        console.log(jwt);

        if (jwt) {
            const accessToken = (JSON.parse(jwt) as JwtAuth).accessToken;
            console.log(accessToken);
            req = req.clone({
                setHeaders: { Authorisation: `Bearer ${jwt}` }
            });
        }

        return next.handle(req);
    }
}