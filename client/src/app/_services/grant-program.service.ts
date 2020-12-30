import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class GrantProgramService {

  constructor(private http: HttpClient) { }

  getGrant(){
    return this.http.get(environment.baseUrl + "grantprogram"); 
  }

  postGrant(formData){
    return this.http.post(environment.baseUrl + "grantprogram", formData ); 
  }
  putGrant(formData){

    return this.http.put(environment.baseUrl + "grantprogram/" + formData.Id, formData ); 
  }
  deleteGrant(id){
    debugger
    return this.http.delete(environment.baseUrl + "grantprogram/" + id); 
  }
}
