import { query, stagger, style, transition, trigger, useAnimation } from '@angular/animations';
import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { dropDown } from '../animation';
import { EducationService } from '../_services/education.service';
import { EducationDetails } from '../_model/educationDetails';

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

  constructor(private fb: FormBuilder, private educationService: EducationService) {
    this.GetDetails(); 
  }

  ngOnInit(): void {
  }

  onSubmitApplicant() { }

  UpdateEducation(fg: FormGroup) {


  }
  delete(id: number) {

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
    this.educationService.getEducationDetails().subscribe(
      response => {
 
        if (Object.keys(response).length === 0)
          this.InitializeEducationalDetails();
        else {
          (response as []).forEach((education: EducationDetails) => {
            this.formModelEducation.push(this.fb.group({
              id : [education.id], 
              applicantId : [education.applicantId], 
              courseName : [education.courseName], 
              country : [education.country], 
              institutionName : [education.institutionName], 
              yearOfCompletion : [education.yearOfCompletion]
            }
            ));

          }
          );

        }
      });
  }

}

