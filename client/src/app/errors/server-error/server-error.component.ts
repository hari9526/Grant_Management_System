import { transition, trigger, useAnimation } from '@angular/animations';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { dropDownDeepAndUp } from 'src/app/animation';

@Component({
  selector: 'app-server-error',
  templateUrl: './server-error.component.html',
  styleUrls: ['./server-error.component.css'], 
  animations: [
   
    trigger('itemAnim', [
      //Entry Animation
      transition('void=>*', [
        useAnimation(dropDownDeepAndUp)
      ])
    ]), 
  ]
})
export class ServerErrorComponent implements OnInit {
  error: any
  constructor(private router: Router) {
    const navigation = this.router.getCurrentNavigation();
    this.error = navigation?.extras?.state?.error;
  }
  ngOnInit(): void {
  }

}
