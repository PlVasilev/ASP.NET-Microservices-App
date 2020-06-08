import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  logoutHandler(){
    // this.authGuard.isAdmin =false;
    // this.authGuard.isLogged = false;
    // this.userService.logout();
  }

}
