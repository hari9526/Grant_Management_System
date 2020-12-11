import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { User } from './_model/user';
import { AccountService } from './_services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'client';
  user: any;
  constructor(private http: HttpClient, private accountService : AccountService) {

  }
  ngOnInit() {
    this.setCurrentUsers(); 
    
  }
  setCurrentUsers() {
    const user : User = JSON.parse(localStorage.getItem('user')); 
    this.accountService.setCurrentUsers(user);     
  }

}
