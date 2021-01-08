import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { ApplicantDetail } from '../_model/applicantDetail';
import { Country } from '../_model/country';
import { State } from '../_model/state';

@Injectable({
  providedIn: 'root'
})
export class ApplicantdetailsService {

  constructor(private http : HttpClient) { }

  getApplicantDetails(id){
    return this.http.get<ApplicantDetail>(environment.baseUrl + "applicant/" + id); 
  }

  saveApplicantDetails(formData, id){
    
    return this.http.put(environment.baseUrl + "applicant/" + id, formData); 
  }

  saveGrantDetails(userGrantMapping){
    
    return this.http.post(environment.baseUrl + "applicant/grantdetails", userGrantMapping); 

  }

  getCountryList(){
    return this.http.get<Country []>(environment.baseUrl + "country"); 
  }

  getStateList(countryId : number){
    return this.http.get<State []>(environment.baseUrl + "country/" + countryId); 
  }
}
