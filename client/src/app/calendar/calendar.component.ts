import { Component, forwardRef, Input, OnInit } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';
import * as moment from 'moment';

@Component({
  selector: 'app-calendar',
  templateUrl: './calendar.component.html',
  styleUrls: ['./calendar.component.css'],
  providers: [{
    provide : NG_VALUE_ACCESSOR, 
    useExisting : forwardRef(() => CalendarComponent), 
    multi : true
  }]
})
export class CalendarComponent implements OnInit, ControlValueAccessor {

  @Input() placeholder: string;
  @Input() minDate : Date; 
  public minimumDate : Date; 
  public valueDate: Date; 
  private onTouchedCallback: () => {};
  private onChangeCallback: (_: any) => {};


  constructor() { 
    this.placeholder
 
 
  }
  ngOnInit(): void {

  }
  minDateCorrection(){
    return this.minimumDate = moment(this.minDate, ["YYYY-MM-DD"]).toDate();
  }

  //This will will write the value to the view 
  //if the the value changes occur on the model programmatically
  writeValue(obj: any): void {
  
    
    const dateObj = moment(obj, ["YYYY-MM-DD"]); 
  
    if(dateObj.isValid())
      this.valueDate = dateObj.toDate(); 
  }

  //When the value in the UI is changed,
  // this method will invoke a callback function
  registerOnChange(fn: any): void {
    this.onChangeCallback = fn;
  }
  //When the element is touched, this method will get called
  registerOnTouched(fn: any): void {
    
    this.onTouchedCallback = fn;
  }


  setDisabledState?(isDisabled: boolean): void {
    throw new Error('Method not implemented.');
  }
  onFocus() {
    
    this.onTouchedCallback();
  }

  public onValueChange(value: any) {
    
    const dateObj = moment(value);
    if (dateObj.isValid()) {
      const formatedValue = dateObj.format("YYYY-MM-DD");
    
      this.onChangeCallback(formatedValue);
    } else {
      this.onChangeCallback(null);
    }
  }

  

}
