import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { AccountService } from '../_services/account.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private accountServices : AccountService, private router : Router){

  }

  canActivate(): Observable<boolean>{
    return this.accountServices.currentUser$.pipe(
      map(user => {
        if(user) {
          if(user.userType == "Admin")
            return true; 
          else if(user.userType == "Applicant"){
            this.router.navigate(['/applicant']); 
            return false; 
          }
        }
          
        else{
          this.router.navigate(['/user/login']);
          return false; 

        }
         
      })
    ); 
  }
  
}
