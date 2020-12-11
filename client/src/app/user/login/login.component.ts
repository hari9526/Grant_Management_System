import { Component, Inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from 'src/app/_services/account.service';
import { FormBuilder, Validators } from '@angular/forms';
import { Login } from 'src/app/_model/login';
import {User} from 'src/app/_model/user'; 
import {ToastrService } from 'ngx-toastr';



@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  isLoading: boolean = false;
  loginButtonText: string = "Log in";
  constructor(  public accountService: AccountService, private fb: FormBuilder) { }

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
   
      },
      err => {
  
        this.isLoading = false,
        this.loginButtonText = "Log in", 
        console.log(err)
      }
    );

  }

}
