import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import { Login } from '../_model/login';
import { Register } from '../_model/register';
import { User } from '../_model/user';
import { map } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = "https://localhost:5001/api/";
  private currentUser = new ReplaySubject<User>(1);
  currentUser$ = this.currentUser.asObservable();


  constructor(private http: HttpClient, private toastr: ToastrService) {
    console.log(this.currentUser$)
   }

  register(model: any) {
    return this.http.post(this.baseUrl + "account/register", model).pipe(
      map((response : User) =>{
        if(response){
          this.toastr.success("Account is created successfully:)", "Success!"); 
          return response; 
        }
      })
    );
  }

  login(model: any) {
    return this.http.post(this.baseUrl + "account/login", model).pipe(
      map((response: User) => {
        const user = response;
        if (user) {
          this.toastr.success("Welcome!");
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUser.next(user);          
        }
      })
    );
  }


  logout() {
    localStorage.removeItem('user');
    this.currentUser.next(null);
  }

  setCurrentUsers(user: User){
    this.currentUser.next(user); 
  }

  

}
