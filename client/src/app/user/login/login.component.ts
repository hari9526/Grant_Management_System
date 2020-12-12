import { Component, Inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from 'src/app/_services/account.service';
import { FormBuilder, Validators } from '@angular/forms';
import { Login } from 'src/app/_model/login';
import {User} from 'src/app/_model/user'; 
import {ToastrService } from 'ngx-toastr';
import { transition, trigger, useAnimation } from '@angular/animations';
import { dropDownSmall, smallToNormal } from 'src/app/animation';



@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'], 
  animations: [
    trigger('picAnim', [
      //Entry Animation
      transition('void=>*', [
        useAnimation(smallToNormal)
      ])
    ]), 
    trigger('itemAnim', [
      //Entry Animation
      transition('void=>*', [
        useAnimation(dropDownSmall)
      ])
    ])   
  ]
})
export class LoginComponent implements OnInit {
  isLoading: boolean = false;
  loginButtonText: string = "Log in";
  constructor(  public accountService: AccountService, private fb: FormBuilder, private router : Router) { }

  ngOnInit(): void {
  }


  formModel = this.fb.group(
    {
      Email: ['', [Validators.required, Validators.email]],
      Password: ['', [Validators.required, Validators.minLength(4)]]
    }
  );
  onSubmit() {
    this.isLoading = true;
    this.loginButtonText = "Logging in!";
    var body: Login = {
      UserName: this.formModel.value.Email,
      Password: this.formModel.value.Password
    };
    this.accountService.login(body).subscribe(
      (res: any) => {
        this.isLoading = false,
        this.loginButtonText = "Log in"
        this.router.navigateByUrl('/admin');
   
      },
      err => {
  
        this.isLoading = false,
        this.loginButtonText = "Try again?", 
        console.log(err)
      }
    );

  }

}
