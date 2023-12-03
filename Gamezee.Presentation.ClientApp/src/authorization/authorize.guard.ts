import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Router, RouterStateSnapshot, UrlTree } from "@angular/router";
import { Observable } from "rxjs";
import { AuthorizeService } from "./authorize.service";

@Injectable({
    providedIn: 'root'
  })
  export class AuthorizeGuard  {
    constructor(private authService: AuthorizeService, private router: Router) {        
    }

    canActivate():| Observable<boolean | UrlTree>
    | Promise<boolean | UrlTree>
    | boolean
    | UrlTree {
        throw new Error("Method not implemented.");
    }
  }
