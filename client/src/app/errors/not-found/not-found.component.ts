import { transition, trigger, useAnimation } from '@angular/animations';
import { Component, OnInit } from '@angular/core';
import { dropDownDeep, dropDownDeepAndUp, smallToNormal } from 'src/app/animation';

@Component({
  selector: 'app-not-found',
  templateUrl: './not-found.component.html',
  styleUrls: ['./not-found.component.css'], 
  animations: [
   
    trigger('itemAnim', [
      //Entry Animation
      transition('void=>*', [
        useAnimation(dropDownDeepAndUp)
      ])
    ]), 
  ]
})
export class NotFoundComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
