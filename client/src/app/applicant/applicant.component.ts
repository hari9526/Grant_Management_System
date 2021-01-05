import { query, stagger, style, transition, trigger, useAnimation } from '@angular/animations';
import { stringify } from '@angular/compiler/src/util';
import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { environment } from 'src/environments/environment';
import { bigToNormal, dropDown, dropDownDeepAndUp, dropDownSmall, smallToNormal } from '../animation';
import { ApplicantDetail } from '../_model/applicantDetail';
import { GrantProgram } from '../_model/grantprogram';
import { UserGrantMapping } from '../_model/userGrantMapping';
import { AccountService } from '../_services/account.service';
import { ApplicantdetailsService } from '../_services/applicantdetails.service';
import { GrantProgramService } from '../_services/grant-program.service';


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
    ]), 
    trigger('listAnim', [
      transition('* => *', [

        query(':enter', style({ opacity: 0 }), { optional: true }),

        query(':enter', stagger('80ms', [
          useAnimation(dropDown)]), { optional: true }),

        // query(':leave', stagger('50ms', [
        //   useAnimation(dropUpAnimation)]), { optional: true })

      ])
    ])

  ]
})

export class ApplicantComponent implements OnInit {
  buttonTextApplicant: string = "Save details";
  isLoading: boolean = false;
  userId: number = 0;
  formData: FormGroup;
  applicantDetails: ApplicantDetail;
  grantApplied: UserGrantMapping;
  grantArrayList: GrantProgram[] = [];




  constructor(private fb: FormBuilder,
    private router: Router,
    private applicantService: ApplicantdetailsService,
    private accountService: AccountService,
    private toastr: ToastrService,
    private grantservice: GrantProgramService) {
    this.currentUserId();
    this.getApplicantDetails();
    this.getGrantList();

  }

  ngOnInit(): void {

  }

  getGrantList() {
    this.grantservice.getActiveGrant().subscribe(response => {
      (response as []).map((grantList: GrantProgram) =>
        this.grantArrayList.push(grantList))
    });

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
            this.formData= 
            this.fb.group({
              Id: [response.id],
              GrantProgram: [0, Validators.required],
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


  saveApplicant() {
    this.isLoading = true;
    this.buttonTextApplicant = "Saving Details...";
    this.applicantDetails = {
      id: this.formData.value.Id,
      firstName: this.formData.value.FirstName,
      lastName: this.formData.value.LastName,
      email: this.formData.value.Email,
      dateOfBirth: this.formData.value.DateOfBirth,
      country: this.formData.value.Country,
      state: this.formData.value.State,
      disabled: this.formData.value.PhysicallyDisabled,
      address: this.formData.value.Address,
      city: this.formData.value.City,
      postalCode: this.formData.value.PostalCode,
      mobile: this.formData.value.Mobile,
      phone: this.formData.value.Phone

    }
    console.log(this.formData.value.GrantProgram)
    this.applicantService.saveApplicantDetails(this.applicantDetails, this.userId)
      .subscribe(
        (response: any) => {
          this.saveGrantProgramDetails();
        },
        (error: any) => {
          this.isLoading = false;
          this.buttonTextApplicant = "Try again?"
        }

      );
  }

  saveGrantProgramDetails() {

    this.grantApplied = {
      userId: this.userId,
      grantId: parseInt(this.formData.value.GrantProgram)
    }
    console.log("HI" + this.grantApplied.grantId)
    this.applicantService.saveGrantDetails(this.grantApplied).subscribe(

      (response: any) => {
        this.isLoading = false;
        this.buttonTextApplicant = "Update again?"
        this.toastr.success("Updated!");
      },
      (error: any) => {
        this.isLoading = false;
        this.buttonTextApplicant = "Try again?"
      }

    );
  }




}
