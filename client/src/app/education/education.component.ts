import { query, stagger, style, transition, trigger, useAnimation } from '@angular/animations';
import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { dropDown } from '../animation';
import { EducationService } from '../_services/education.service';
import { EducationDetails } from '../_model/educationDetails';
import { Toast, ToastrService } from 'ngx-toastr';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-education',
  templateUrl: './education.component.html',
  styleUrls: ['./education.component.css'],
  animations: [
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
export class EducationComponent implements OnInit {
  formModelEducation: FormArray = this.fb.array([]);
  userId: number = 0;

  constructor(private fb: FormBuilder,
    private educationService: EducationService,
    private toastr: ToastrService,
    private acccountService: AccountService) {
    this.currentUserId();
    this.GetDetails();
  }

  ngOnInit(): void {
  }
  currentUserId() {
    this.acccountService.currentUser$.subscribe(x => {
      this.userId = x.id;
    });
  }

  onSubmitApplicant() { }

  submit(fg: FormGroup) {
    debugger;
    if (fg.value.id == 0) {
      this.educationService.saveDetail(fg.value, this.userId).subscribe(
        (response: any) => {
          fg.patchValue({ id: response.id });
          fg.patchValue({ applicantId: response.applicantId });
          this.toastr.success("Details Added!");
        }
      );

    }
    else {
      this.educationService.editDetail(fg.value).subscribe(
        (response: any) => { this.toastr.success("Edited!"); }
      );
    }



  }
  delete(Id, i) {
    if (Id == 0)
      this.formModelEducation.removeAt(i);
    else if (confirm("Do you want to delete?")) {

      this.educationService.delete(Id).subscribe(
        (response: any) => {
          this.formModelEducation.removeAt(i);
          this.toastr.success("Deleted!");
        }
      );
    }

  }
  InitializeEducationalDetails() {
    this.formModelEducation.push(this.fb.group({
      id: [0],
      applicantId: [0],
      courseName: ['', Validators.required],
      country: ['', Validators.required],
      institutionName: ['', Validators.required],
      yearOfCompletion: [0, Validators.required]
    }));
  }


  GetDetails() {    
    this.educationService.getEducationDetails(this.userId).subscribe(
      response => {

        if (Object.keys(response).length === 0)
          this.InitializeEducationalDetails();
        else {
          (response as []).forEach((education: EducationDetails) => {
            this.formModelEducation.push(this.fb.group({
              id: [education.id],
              applicantId: [education.applicantId],
              courseName: [education.courseName],
              country: [education.country],
              institutionName: [education.institutionName],
              yearOfCompletion: [education.yearOfCompletion]
            }
            ));
          }
          );
        }
      });
  }

}

