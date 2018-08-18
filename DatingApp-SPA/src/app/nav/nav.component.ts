import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
model: any = {};
  constructor(public authService: AuthService, private alertify: AlertifyService) { }

  ngOnInit() {
  }


  login() {
   this.authService.login(this.model).subscribe(next => {
     this.alertify.success('logged in successfully');
   }, error => {
<<<<<<< HEAD
    this.alertify.error(error);
=======
     console.log(error);
>>>>>>> 6cb9c64912fc455099c9da9218d434a790e4bb00

   });
  }
  loggedIn() {
   return this.authService.loggedIn();
  }

  logout() {
    localStorage.removeItem('token');
    this.alertify.message('logged out');
  }
}
