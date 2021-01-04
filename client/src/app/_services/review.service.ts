import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ReviewService {

  constructor(private http: HttpClient) { }

  getReviewDetails() {
    return this.http.get(environment.baseUrl + "review");
  }

  UpdateReview(data) {
    debugger; 
    return this.http.put(environment.baseUrl + "review", data);

  }
}
