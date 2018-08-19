import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '../../../node_modules/@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
model: any = {};
  constructor(public authService: AuthService, private alertify: AlertifyService, private router: Router) { }

  ngOnInit() {
  }

// stucribe method takes 3 parameters, first one is success, second is error 3th is on complete.
  login() {
   this.authService.login(this.model).subscribe(next => {
     this.alertify.success('logged in successfully');
   }, error => {
    this.alertify.error(error);

   }, () => {
     this.router.navigate(['/members']);
   });
  }

  loggedIn() {
   return this.authService.loggedIn();
  }

  logout() {
    localStorage.removeItem('token');
    this.alertify.message('logged out');
    this.router.navigate(['/home']);
  }
}
