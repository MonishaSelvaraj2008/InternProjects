import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { LoginService } from './login.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  service: any;


  constructor(private loginService:LoginService,private router:Router) {}
  canActivateChild(childRoute: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    console.log("can activate child")
       if(!this.service.isAdminUser()){
  alert("You are not admin and not allowed to edit the product");
  return false;
}
return true;
  }
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): boolean{
      if(!this.service.isUserLoggedIn()){
        alert("You are not logged in to view the page");
        this.router.navigate(["Login"],{queryParams:{retUrl:route.url}}); //localhost:4200/login?retUrl=product

        return false;
      }
      return true;
    }
  }

