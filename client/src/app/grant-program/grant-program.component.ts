import { query, stagger, style, transition, trigger, useAnimation } from '@angular/animations';
import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Toast, ToastrService } from 'ngx-toastr';
import { bigToNormalSmallAnimation, dropDown, dropUpAnimation } from '../animation';
import { GrantProgram } from '../_model/grantprogram';
import { GrantProgramService } from '../_services/grant-program.service';

@Component({
  selector: 'app-grant-program',
  templateUrl: './grant-program.component.html',
  styleUrls: ['./grant-program.component.css'],
  animations: [

    trigger('itemAnim', [
      //Entry Animation
      transition('void=>*', [
        useAnimation(bigToNormalSmallAnimation)
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
export class GrantProgramComponent implements OnInit {
  grantProgramForms: FormArray = this.fb.array([]);
  bsValue = new Date();
  constructor(private fb: FormBuilder, private grantservice: GrantProgramService, private toaster: ToastrService) { }

  ngOnInit(): void {
    // this.grantservice.getGrant().subscribe(response => {
    //   //this.grantProgramForms = response as FormArray;       
    // }); 


    this.grantservice.getGrant().subscribe(
      response => {
        if (response == null)
          this.AddGrantProgramForms();
        else {
          //We are generating formarray as per the data received from 
          //the api
          console.log(response);
          (response as []).forEach((grantProgram: GrantProgram) => {
            this.grantProgramForms.push(this.fb.group({
              Id: [grantProgram.id],
              ProgramName: [grantProgram.programName, Validators.required],
              ProgramCode: [grantProgram.programCode, Validators.required],
              StartDate: [grantProgram.startDate, Validators.required],
              EndDate: [grantProgram.endDate, Validators.required],
              Status: [grantProgram.status]
            }
            ));
          }
          );
          console.log(this.grantProgramForms)
        }
      }
    );
  }



  AddGrantProgramForms() {
    this.grantProgramForms.push(this.fb.group({
      Id: [0],
      ProgramName: ['', Validators.required],
      ProgramCode: ['', Validators.required],
      StartDate: ['', Validators.required],
      EndDate: ['', Validators.required],
      Status: [false]
    }));
  }
  recordSubmit(fg: FormGroup) {
    if (fg.value.Id == 0) {
      this.grantservice.postGrant(fg.value).subscribe(
        (response: any) => {
          fg.patchValue({ Id: response.id });
          this.toaster.success("New record added!");
        }
      );
    }
    else {
      this.grantservice.putGrant(fg.value).subscribe(
        (response: any) => {
          this.toaster.success("Edited Successfully!");
        }

      );

    }


  }
  delete(Id, i) {
    if (Id == 0) {
      this.grantProgramForms.removeAt(i);
    }
    else if (confirm("Sure you want to delete?")) {
      this.grantservice.deleteGrant(Id).subscribe(
        (response: any) => {
          this.grantProgramForms.removeAt(i);
          this.toaster.success("Deletion success!")
        }
      )

    }



  }
}
