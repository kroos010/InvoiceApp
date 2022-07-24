import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dashboard-layout',
  templateUrl: './dashboard-layout.component.html',
  styleUrls: ['./dashboard-layout.component.scss']
})
export class DashboardLayoutComponent implements OnInit {

  constructor() { }

  showMenuNavbar = false;
  showHeaderProfileDropdown = false;

  ngOnInit(): void {
  }

  toggleNavbar(){
    this.showMenuNavbar = !this.showMenuNavbar;
  }

  toggleHeaderProfileDropdown(){
    this.showHeaderProfileDropdown = !this.showHeaderProfileDropdown;
  }

}
