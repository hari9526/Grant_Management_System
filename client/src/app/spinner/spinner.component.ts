import { transition, trigger, useAnimation } from '@angular/animations';
import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { dropDownDeepAndUp, smallToNormal } from '../animation';
import { SpinnerService } from '../_services/spinner.service';

@Component({
  selector: 'app-spinner',
  templateUrl: './spinner.component.html',
  styleUrls: ['./spinner.component.css'], 
  animations: [
   
    trigger('itemAnim', [
      //Entry Animation
      transition('void=>*', [
        useAnimation(smallToNormal)
      ])
    ]), 
  ]
})
export class SpinnerComponent implements OnInit {
  showSpinner = true;
  constructor(private spinnerService: SpinnerService,
    private cdRef: ChangeDetectorRef) {
    
  }
  ngOnInit(): void {
    this.init();
  }
  init() {
    this.spinnerService.getSpinnerObservable().subscribe((status) => {
      
      this.showSpinner = status === 'start'; 
      //in some componenets we have to manually specify the change. 
      //for that we use detetchanges. 
      this.cdRef.detectChanges(); 
    }
    );

  }



}
