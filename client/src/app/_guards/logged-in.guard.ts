import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { AccountService } from '../_services/account.service';

@Injectable({
  providedIn: 'root'
})
export class LoggedInGuard implements CanActivate {

  constructor(private router: Router, private accountServices: AccountService) {

  }
  canActivate(): Observable<boolean> {
    return this.accountServices.currentUser$.pipe(
      map(user=>{
        if(user){       
          this.router.navigate(['/grant-program']);
          return false;         
        }
        else{
          return true; 
        }
                                
      })
    );
  }

}
