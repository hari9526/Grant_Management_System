import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApplicantdetailsService {

  constructor(private http : HttpClient) { }

  getApplicantDetails(){
    this.http.get(environment.baseUrl + ""); 
  }
}
