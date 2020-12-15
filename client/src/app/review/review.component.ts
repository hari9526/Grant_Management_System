import { query, stagger, style, transition, trigger, useAnimation } from '@angular/animations';
import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { dropDown, smallToNormal } from '../animation';

@Component({
  selector: 'app-review',
  templateUrl: './review.component.html',
  styleUrls: ['./review.component.css'],
  animations: [

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

  applicantList : FormArray = this.fb.array([]); 

  constructor(private fb: FormBuilder ) {
    this.AddApplicants(); 
    console.log(this.applicantList.controls); 
   }

  ngOnInit(): void {
  }
  AddApplicants() {
    this.applicantList.push(this.fb.group({
      
      ApplicantName: ['Steve'],
      ProgramCode: ['Jobs'],
      Country: ['India'],
      ApplicationStatus: ['Approved'],
      ReviewerStatus: ['Hello']
    }));
  }
}
