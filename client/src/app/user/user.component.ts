import { transition, trigger, useAnimation } from '@angular/animations';
import { Component, OnInit } from '@angular/core';
import { dropDownSmall } from '../animation';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css'], 
  animations: [
   
    trigger('itemAnim', [
      //Entry Animation
      transition('void=>*', [
        useAnimation(dropDownSmall)
      ])
    ])
  ]
})
export class UserComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
