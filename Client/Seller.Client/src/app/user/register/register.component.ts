import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent  {

  constructor(private userService: UserService) { }

  ngOnInit() {
  }

  registerHandler(formValue){
    this.userService.register(formValue).subscribe(data => {
      console.log(data)
    })
  }

}
