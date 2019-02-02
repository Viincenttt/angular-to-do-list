import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/authentication/auth.service';
import { UserLoginResponse } from 'src/app/models/authentication/userloginresponse';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.less']
})
export class HeaderComponent implements OnInit {
  public isAuthenticated = false;

  constructor(private authService: AuthService) { }

  ngOnInit() {
    this.authService.currentUser.subscribe((user: UserLoginResponse) => {
      this.isAuthenticated = user != null;
    });
  }
}
