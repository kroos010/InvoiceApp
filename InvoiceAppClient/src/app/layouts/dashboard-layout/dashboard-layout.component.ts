import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { interval, startWith, Subscription, switchMap, tap } from 'rxjs';
import { AuthService } from 'src/app/core/service/auth.service';
import { AuthenticationTokenManagerService, TokenExpirationStatus } from 'src/app/core/service/authentication-token-manager.service';

@Component({
  selector: 'app-dashboard-layout',
  templateUrl: './dashboard-layout.component.html',
  styleUrls: ['./dashboard-layout.component.scss']
})
export class DashboardLayoutComponent implements OnInit {

  // timeInterval: Subscription

  constructor(private router: Router, private authenticationTokenManagerService: AuthenticationTokenManagerService) {

    this.authenticationTokenManagerService.isTokenAlmostExpired().subscribe((response: TokenExpirationStatus) => {

      if (response.completelyExpired) {
        this.inactiveAlert = false
        this.router.navigate(["/"])
        console.log('Redirect now?')
      }
      if (response.almostExpired) {
        this.inactiveAlert = true
        console.log('ALmost expire now?')
      }
    })
  }

  showMenuNavbar = false;
  showHeaderProfileDropdown = false;
  inactiveAlert = false;

  ngOnInit(): void {

  }

  toggleNavbar() {
    this.showMenuNavbar = !this.showMenuNavbar;
  }

  toggleHeaderProfileDropdown() {
    this.showHeaderProfileDropdown = !this.showHeaderProfileDropdown;
  }

}
