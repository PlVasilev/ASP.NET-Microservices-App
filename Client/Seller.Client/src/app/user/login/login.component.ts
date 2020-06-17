import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/user/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'] 
})
export class LoginComponent {

  constructor(private userService: UserService,private router: Router) { }

  loginHandler(formValue) {
    this.userService.login(formValue).subscribe(data => {
      console.log(data)
      this.userService.saveToken(data['userId'],data['token'],data['username'])
      this.router.navigate([`/listing/all`])
    })
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
