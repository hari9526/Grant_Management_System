import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { AccountService } from './account.service';

@Injectable({
  providedIn: 'root'
})
export class EducationService {

  
  constructor(private http: HttpClient, private acccountService : AccountService) { }

  getEducationDetails(userId){
 
    return this.http.get(environment.baseUrl + "education/" + userId);    
  }

  saveDetail(formData, userId){
   
    formData.applicantId = userId; 
    return this.http.post(environment.baseUrl + "education/save", formData); 
  }

  editDetail(formData){
    return this.http.put(environment.baseUrl + "education/" + formData.id, formData); 
  }
  
  delete(id){
    return this.http.delete(environment.baseUrl + "education/" + id); 
  }

}
