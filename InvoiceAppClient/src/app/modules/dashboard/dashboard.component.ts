import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {



  constructor(private http: HttpClient) {
    this.http.get("https://localhost:7178/weatherforecast").subscribe(response => {
      console.log(response)
    }, error => {
      console.log(error)
    });
  }

  ngOnInit(): void {
  }

}
