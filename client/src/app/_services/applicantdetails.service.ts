import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApplicantdetailsService {

  constructor(private http : HttpClient) { }

  getApplicantDetails(id){
    return this.http.get(environment.baseUrl + "applicant/" + id); 
  }

  saveApplicantDetails(formData, id){
    return this.http.put(environment.baseUrl + "applicant/" + id, formData); 
  }
  
}
