import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http'; 
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TooltipModule } from 'ngx-bootstrap/tooltip';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { UserComponent } from './user/user.component';
import { LoginComponent } from './user/login/login.component';
import { RegisterComponent } from './user/register/register.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
import { ErrorInterceptor } from './_interceptors/error.interceptor';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { TestErrorComponent } from './errors/test-error/test-error.component';
import { NavComponent } from './nav/nav.component';
import { GrantProgramComponent } from './grant-program/grant-program.component';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { ReviewComponent } from './review/review.component';
import { ApplicantComponent } from './applicant/applicant.component';
import { EducationComponent } from './education/education.component';
import { CalendarComponent } from './calendar/calendar.component';




@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    LoginComponent,
    RegisterComponent,
    NotFoundComponent,
    ServerErrorComponent,
    TestErrorComponent,
    NavComponent,
    GrantProgramComponent,
    ReviewComponent,
    ApplicantComponent,
    EducationComponent,
    CalendarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule, 
    HttpClientModule, 
    BrowserAnimationsModule, 
    BsDatepickerModule.forRoot(), 
    BsDropdownModule.forRoot(), 
    TooltipModule.forRoot(),
    FormsModule,
    ReactiveFormsModule, 
    ToastrModule.forRoot({
      progressBar:true, 
      positionClass: 'toast-bottom-right'
    })
    

  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
