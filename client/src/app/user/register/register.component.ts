import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { AccountService } from 'src/app/_services/account.service';
import { ToastrService } from 'ngx-toastr';
import { transition, trigger, useAnimation } from '@angular/animations';
import { dropDownSmall } from 'src/app/animation';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'], 
  animations: [
   
    trigger('itemAnim', [
      //Entry Animation
      transition('void=>*', [
        useAnimation(dropDownSmall)
      ])
    ])   
  ]
})
export class RegisterComponent implements OnInit {
  signUpButtonText : string = "Sign up"; 
  isLoading : boolean = false; 
  constructor(private fb: FormBuilder, private accountService : AccountService) { }

  ngOnInit(): void {
  }

  formModel = this.fb.group({
    FirstName: ['', [Validators.required]],
    LastName: ['', [Validators.required]],
    Email: ['', [Validators.required, Validators.email]],
    Passwords: this.fb.group({
      Password: ['', [Validators.required, Validators.minLength(4)]],
      ConfirmPassword: ['', [Validators.required]]
    }, { validator: this.ComparePasswords })
  })
  ComparePasswords(fb: FormGroup) {
    let confirmPasswordCtrl = fb.get('ConfirmPassword');
    if (confirmPasswordCtrl.errors == null || 'passwordMismatch' in confirmPasswordCtrl.errors) {
      if (confirmPasswordCtrl.value != fb.get('Password').value)
        confirmPasswordCtrl.setErrors({ passwordMismatch: true });
      else
        confirmPasswordCtrl.setErrors(null);
    }

  }

  onSubmit(){
    this.isLoading = true; 
    this.signUpButtonText = "Creating account..."; 
    var body ={
      FirstName : this.formModel.value.FirstName, 
      LastName : this.formModel.value.LastName, 
      Email : this.formModel.value.Email, 
      Password : this.formModel.value.Passwords.Password
    }
    this.accountService.register(body).subscribe(
      (res : any)=>{
        this.isLoading = false; 
        this.signUpButtonText = "Create again?"; 
      }, 
      err => {
  
        this.isLoading = false,
        this.signUpButtonText = "Try again?"
    
      }
    )

  }

}
