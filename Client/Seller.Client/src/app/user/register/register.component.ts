import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UserService } from 'src/app/user/user.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent  {

  constructor(
    private userService: UserService,
    private toastrService: ToastrService,
    private router: Router) { }

  ngOnInit() {
  }

  registerHandler(formValue){
    console.log(formValue)
    this.userService.register(formValue).subscribe(data => {
      this.toastrService.success("Registered")
      this.router.navigate([`/user/login`])
    })
  }

}
