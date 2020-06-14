import { Injectable, Input } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { UserService } from './user/user.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  isLogged = false;
  isAdmin = false;

  constructor(
      private userService: UserService,
      private router: Router
      ) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    if(this.userService.getToken()){
        this.isLogged = true;
        if(this.userService.getUsername() === "admin") {
          this.isAdmin = true;
         // console.log(this.isAdmin);
          
        }else{
        //  console.log(this.isAdmin);
        }
    }

    if (this.isLogged === route.data.isLogged){   
        return true;
    }
    else if(this.isAdmin === route.data.isAdmin){
      return true;
    }
    else{
        this.router.navigateByUrl('/notauthorized');
    }
  }
}