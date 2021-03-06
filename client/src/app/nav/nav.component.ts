import { transition, trigger, useAnimation } from '@angular/animations';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { dropDownDeep, dropDownSmall, smallToNormal } from '../animation';
import { User } from '../_model/user';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
  animations: [
    trigger('textAnim', [
      //Entry Animation
      transition('void=>*', [
        useAnimation(smallToNormal)
      ])
    ]),
    trigger('itemAnim', [
      //Entry Animation
      transition('void=>*', [
        useAnimation(dropDownDeep)
      ])
    ])
  ]
})
export class NavComponent implements OnInit {

  public IsItAdmin: boolean ;

  constructor(public accountService: AccountService, private router: Router) {

    this.IsItAdminUser();
   
  }

  ngOnInit(): void {



  }
  IsItAdminUser() {
    this.accountService.currentUser$.subscribe(type => {
      if (type.userType == "Admin")
        this.IsItAdmin = true;
      else
        this.IsItAdmin = false;
    });
  }
  logout() {

    this.accountService.logout();
    this.router.navigateByUrl('/user/login');
  }

}
