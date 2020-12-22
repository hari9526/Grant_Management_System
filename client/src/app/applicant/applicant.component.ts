import { transition, trigger, useAnimation } from '@angular/animations';
import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { bigToNormal, dropDownDeepAndUp, dropDownSmall, smallToNormal } from '../animation';
import { EducationComponent } from '../education/education.component';

@Component({
  selector: 'app-applicant',
  templateUrl: './applicant.component.html',
  styleUrls: ['./applicant.component.css'], 
  animations:[
    trigger('itemAnim', [
      //Entry Animation
      transition('void=>*', [
        useAnimation(dropDownDeepAndUp)
      ])
    ]), 
    trigger('formAnim', [
      //Entry Animation
      transition('void=>*', [
        useAnimation(smallToNormal)
      ])
    ])

  ]
})

export class ApplicantComponent implements OnInit {
  buttonTextApplicant : string = "Save & Continue"; 
  isLoading : boolean  = false; 
  formModelEducation: FormArray = this.fb.array([]);

  constructor(private fb: FormBuilder, private router : Router) { 
    this.InitializeEducationalDetails(); 
   
    
  }

  ngOnInit(): void {

  }
  formModelApplicant = this.fb.group({
    GrantProgram : ['', Validators.required], 
    FirstName: ['', [Validators.required]],
    LastName: ['', [Validators.required]],
    Email: ['', [Validators.required, Validators.email]],
    Passwords: this.fb.group({
      Password: ['', [Validators.required, Validators.minLength(4)]],
      ConfirmPassword: ['', [Validators.required]]
    }, { validator: this.ComparePasswords }), 
    DateOfBirth : ['', [Validators.required]], 
    Country : ['', [Validators.required]], 
    State : ['', [Validators.required]], 
    PhysicallyDisabled : ['', [Validators.required]], 
    Address : ['', [Validators.required]], 
    City : ['', [Validators.required]], 
    PostalCode : ['', [Validators.required]], 
    Mobile : ['', [Validators.required]], 
    Phone : ['', [Validators.required]]
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

  InitializeEducationalDetails(){
    this.formModelEducation.push(this.fb.group({
      id : [0], 
      applicantId : [0],       
      courseName : ['', Validators.required], 
      country : ['', Validators.required], 
      institutionName : ['', Validators.required], 
      yearOfCompletion : [0, Validators.required]
    }));
    debugger; 
  }



  onSubmitApplicant(){}

  UpdateEducation(fg: FormGroup){}
  delete(id: number){

  }

  goToEducation(){
    this.router.navigateByUrl("/education"); 
  }


}
