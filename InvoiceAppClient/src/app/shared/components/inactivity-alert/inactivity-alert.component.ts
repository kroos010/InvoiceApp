import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/core/service/auth.service';

@Component({
  selector: 'app-inactivity-alert',
  templateUrl: './inactivity-alert.component.html',
  styleUrls: ['./inactivity-alert.component.scss']
})
export class InactivityAlertComponent implements OnInit {

  isModalOpen: boolean = true;

  constructor(private http: HttpClient, private authService: AuthService) { }

  ngOnInit(): void {
  }

  onClick() {

    this.authService.renewToken().subscribe(response => {
      this.isModalOpen = false;
    })
  }

}
