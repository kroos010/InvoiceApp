import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {



  constructor(private http: HttpClient, private router: Router) {
    this.http.get("https://localhost:7248/weatherforecast").subscribe(response => {
      console.log(response)
    }, error => {
      console.log(error)
    });
  }

  ngOnInit(): void {
  }

}
