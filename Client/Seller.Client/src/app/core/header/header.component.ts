import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/user/user.service';
import { AuthGuard } from 'src/app/auth.guard';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {

  constructor(private userService: UserService,private authGuard: AuthGuard) { }

  get username(){return this.userService.getUsername()}
  get token(){return this.userService.getToken()}

  logoutHandler(){
     this.authGuard.isAdmin =false;
     this.authGuard.isLogged = false;
     this.userService.logout();
  }

}
