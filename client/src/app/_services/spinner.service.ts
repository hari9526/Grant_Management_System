import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SpinnerService {
  private count = 0; 
  private spinner = new BehaviorSubject<string>(''); 

  constructor() { }

  getSpinnerObservable() : Observable<string>{
    return this.spinner.asObservable();
  }
  //Api starts
  requestStarted(){
    if(++this.count === 1)
      this.spinner.next('start');
  }
  requestEnded(){
    if(this.count === 0 || --this.count === 0)
      this.spinner.next('stop'); 
  }

  //in case of an error
  resetSpinner(){
    this.count = 0 ;
    this.spinner.next('stop'); 
  }
}
