import { query, stagger, style, transition, trigger, useAnimation } from '@angular/animations';
import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { dropDown, dropDownDeepAndUp, smallToNormal } from '../animation';
import { ReviewService } from '../_services/review.service';
import { ReviewItem } from '../_model/review';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-review',
  templateUrl: './review.component.html',
  styleUrls: ['./review.component.css'],
  animations: [
    trigger('noItemAnim', [
      //Entry Animation
      transition('void=>*', [
        useAnimation(dropDownDeepAndUp)
      ])
    ]),
    trigger('itemAnim', [
      //Entry Animation
      transition('void=>*', [
        useAnimation(smallToNormal)
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
export class ReviewComponent implements OnInit {

  applicantList: FormArray = this.fb.array([]);
  emptyList: boolean = false;

  constructor(private fb: FormBuilder, private reviewService: ReviewService, private toaster: ToastrService) {
    this.initializeApplicant(); 
    this.GetApplicants();
  }

  ngOnInit(): void {
  }
  initializeApplicant() {
    this.applicantList.push(this.fb.group({
      id: [0],
      applicantName: [''],
      programCode: [''],
      country: [''],
      applicationStatus: [''],
      reviewerStatus: [true]
    })     
    );
  }
  GetApplicants() {
    this.reviewService.getReviewDetails().subscribe(response => {

      if (Object.keys(response).length === 0)
        this.emptyList = true;
      else {
        this.applicantList = this.fb.array([]); 
        (response as []).forEach((review: ReviewItem) => {
          this.applicantList.push(this.fb.group({
            id: [review.id],
            applicantName: [review.applicantName],
            programCode: [review.programCode],
            country: [review.country],
            applicationStatus: [review.applicationStatus],
            reviewerStatus: [review.reviewerStatus]
          }
          ));
        }
        );
      }
    });

  }
  UpdateReview(formData: FormGroup) {

    this.reviewService.UpdateReview(formData.value).subscribe(
      (response: any) => {
        this.toaster.success("Updated!")
      }
    );
  }
}
