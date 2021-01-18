import { query, stagger, style, transition, trigger, useAnimation } from '@angular/animations';
import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import * as moment from 'moment';
import { BsDropdownConfig } from 'ngx-bootstrap/dropdown';
import { Toast, ToastrService } from 'ngx-toastr';
import { bigToNormalSmallAnimation, dropDown, dropDownDeepAndUp, dropUpAnimation, fromButtom, smallToNormal } from '../animation';
import { GrantProgram } from '../_model/grantprogram';
import { GrantProgramService } from '../_services/grant-program.service';

@Component({
  selector: 'app-grant-program',
  templateUrl: './grant-program.component.html',
  providers: [{ provide: BsDropdownConfig, useValue: { isAnimated: true, autoClose: true } }],
  styleUrls: ['./grant-program.component.css'],
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
export class GrantProgramComponent implements OnInit {
  grantProgramForms: FormArray = this.fb.array([]);
  emptyList: boolean = false; 
  bsValue = new Date();
  constructor(private fb: FormBuilder, 
              private grantservice: GrantProgramService, 
              private toaster: ToastrService) {
    this.GetGrants(); 
    this.InitializeGrantProgramForms(); 
    
     
    
 

  }

  ngOnInit(): void {

  }
  //For getting list of grants
  GetGrants(){
    this.grantservice.getGrant().subscribe(
      response => {
        if ( Object.keys(response).length === 0)
          this.toaster.info("Create new grant programs!") 
        else {
          //We are generating formarray as per the data received from 
          //the api
          //map and forEach are the same. For iterating through a collection. 
          this.grantProgramForms = this.fb.array([]); 
          (response as []).map((grantProgram: GrantProgram) => {
            this.grantProgramForms.push(this.fb.group({
              Id: [grantProgram.id],
              ProgramName: [grantProgram.programName, Validators.required],
              ProgramCode: [grantProgram.programCode, Validators.required],
              StartDate: [moment(grantProgram.startDate, ["YYYY-MM-DD"]).toDate(), Validators.required],
              EndDate: [grantProgram.endDate, Validators.required],
              Status: [grantProgram.status]
            }
            ));
          }
          );

        }
      }
    );
  }


  InitializeGrantProgramForms() {
    this.grantProgramForms.push(this.fb.group({
      Id: [0],
      ProgramName: ['', Validators.required],
      ProgramCode: ['', Validators.required],
      StartDate: ['', Validators.required],
      EndDate: ['', Validators.required],
      Status: [Validators.required]
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
      if(this.grantProgramForms.length == 0)
            this.InitializeGrantProgramForms();
    }
    else if (confirm("Sure you want to delete?")) {
      
      this.grantservice.deleteGrant(Id).subscribe(
        (response: any) => {
          this.grantProgramForms.removeAt(i);
          this.toaster.success("Deletion success!");
          if(this.grantProgramForms.length == 0)
            this.InitializeGrantProgramForms(); 
        }
      )
      
    }
  }
}
