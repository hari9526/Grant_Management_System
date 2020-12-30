import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { AccountService } from './account.service';

@Injectable({
  providedIn: 'root'
})
export class EducationService {

  userId : number = 0; 
  constructor(private http: HttpClient, private acccountService : AccountService) { }

  getEducationDetails(){
    this.currentUserId()   
    return this.http.get(environment.baseUrl + "education/" + this.userId);    
  }

  saveDetail(formData){
    this.currentUserId(); 
    formData.applicantId = this.userId; 
    return this.http.post(environment.baseUrl + "education/save", formData); 
  }

  editDetail(formData){
    return this.http.put(environment.baseUrl + "education/" + formData.id, formData); 
  }
  
  delete(id){
    return this.http.delete(environment.baseUrl + "education/" + id); 
  }

  currentUserId(){    
    this.acccountService.currentUser$.subscribe(x=> { 
      this.userId = x.id; 
      return this.userId;
    });     
  }
}
