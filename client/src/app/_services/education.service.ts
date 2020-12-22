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
  currentUserId(){    
    this.acccountService.currentUser$.subscribe(x=> { 
      this.userId = x.id; 
      return this.userId;
    });     
  }
}
