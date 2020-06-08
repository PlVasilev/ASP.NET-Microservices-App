import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'] 
})
export class LoginComponent {

  constructor() { }

  loginHandler(data) {
    // this.userService.login(data.username, data.password).then((result) => {
    //   if(result == true){
    //     this.notifier.notify("success", "You have Logged in!");
    //     this.from.reset();
    //   }else{
    //     this.notifier.notify("error", "Wrong Username or Password!");
    //   }
    // }).catch((error) => {
    //   this.notifier.notify("warning", "There was a problem with the site please try again Later!");
    // })  
  }

}
