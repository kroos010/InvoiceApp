import { Component, OnInit } from '@angular/core';
import { interval, startWith, Subscription, switchMap, tap } from 'rxjs';
import { AuthService } from 'src/app/core/service/auth.service';
import { AuthenticationTokenManagerService } from 'src/app/core/service/authentication-token-manager.service';

@Component({
  selector: 'app-dashboard-layout',
  templateUrl: './dashboard-layout.component.html',
  styleUrls: ['./dashboard-layout.component.scss']
})
export class DashboardLayoutComponent implements OnInit {

  // timeInterval: Subscription

  constructor(private authenticationTokenManagerService: AuthenticationTokenManagerService) {

    this.authenticationTokenManagerService.isTokenAlmostExpired().subscribe((response: unknown) => {
      this.inactiveAlert = true
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
