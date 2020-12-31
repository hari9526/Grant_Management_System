import { transition, trigger, useAnimation } from '@angular/animations';
import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { bigToNormal, dropDownDeepAndUp, dropDownSmall, smallToNormal } from '../animation';
import { ApplicantDetail } from '../_model/applicantDetail';
import { AccountService } from '../_services/account.service';
import { ApplicantdetailsService } from '../_services/applicantdetails.service';


@Component({
  selector: 'app-applicant',
  templateUrl: './applicant.component.html',
  styleUrls: ['./applicant.component.css'],
  animations: [
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
  buttonTextApplicant: string = "Save details";
  isLoading: boolean = false;
  userId: number = 0;
  formData: FormGroup;


  constructor(private fb: FormBuilder,
    private router: Router,
    private applicantService: ApplicantdetailsService,
    private accountService: AccountService) {
    this.currentUserId();
    this.getApplicantDetails();

  }

  ngOnInit(): void {

  }

  currentUserId() {
    this.accountService.currentUser$.subscribe(x => {
      this.userId = x.id;
      return this.userId;
    });
  }
  initializeForm() {
    this.formData = this.fb.group({
      Id: [0],
      GrantProgram: ['', Validators.required],
      FirstName: ['', [Validators.required]],
      LastName: ['', [Validators.required]],
      Email: ['', [Validators.required, Validators.email]],
      DateOfBirth: ['', [Validators.required]],
      Country: ['', [Validators.required]],
      State: ['', [Validators.required]],
      PhysicallyDisabled: ['', [Validators.required]],
      Address: ['', [Validators.required]],
      City: ['', [Validators.required]],
      PostalCode: ['', [Validators.required]],
      Mobile: ['', [Validators.required]],
      Phone: ['', [Validators.required]]
    });
  }

  getApplicantDetails() {
    this.applicantService.getApplicantDetails(this.userId).subscribe(
      (response: ApplicantDetail) => {
        if (response == null)
          this.initializeForm();
        else {
          this.formData = this.fb.group({
            Id: [response.id],
            GrantProgram: ['', Validators.required],
            FirstName: [response.firstName, [Validators.required]],
            LastName: [response.lastName, [Validators.required]],
            Email: [response.email, [Validators.required, Validators.email]],
            DateOfBirth: [response.dateOfBirth, [Validators.required]],
            Country: [response.country, [Validators.required]],
            State: [response.state, [Validators.required]],
            PhysicallyDisabled: [response.disabled, [Validators.required]],
            Address: [response.address, [Validators.required]],
            City: [response.city, [Validators.required]],
            PostalCode: [response.postalCode, [Validators.required]],
            Mobile: [response.mobile, [Validators.required]],
            Phone: [response.phone, [Validators.required]]
          });
          console.log(this.formData); 
        }

      }
    );

  }


  saveApplicant() { }



}
