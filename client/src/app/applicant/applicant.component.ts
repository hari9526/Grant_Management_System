import { transition, trigger, useAnimation } from '@angular/animations';
import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { bigToNormal, dropDownDeepAndUp, dropDownSmall, smallToNormal } from '../animation';


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
        useAnimation(dropDownDeepAndUp)
      ])
    ])

  ]
})

export class ApplicantComponent implements OnInit {
  buttonTextApplicant : string = "Save details"; 
  isLoading : boolean  = false; 
  formModelEducation: FormArray = this.fb.array([]);

  constructor(private fb: FormBuilder, private router : Router) { 
    
  }

  ngOnInit(): void {

  }
  formModelApplicant = this.fb.group({
    GrantProgram : ['', Validators.required], 
    FirstName: ['', [Validators.required]],
    LastName: ['', [Validators.required]],
    Email: ['', [Validators.required, Validators.email]], 
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

  initializeForm(){
    
  }





  onSubmitApplicant(){}



}
