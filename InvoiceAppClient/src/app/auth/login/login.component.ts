import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  invalidLogin: boolean;

  loginForm = this.formBuilder.group({
    name: '',
    password: ''
  });

  constructor(private router: Router, private formBuilder: FormBuilder, private http: HttpClient) {
    this.invalidLogin = false;
  }

  ngOnInit(): void {
  }

  onSubmit() {
    const formResult = this.loginForm.value;

    const credentials = {
      'username': formResult.name,
      'password': formResult.password
    }

    this.http.post("https://localhost:7178/api/auth/login", credentials).subscribe(response => {
      const token = (<any>response).token;

      localStorage.setItem("jwt", token);
      this.invalidLogin = false;
      this.router.navigate(["/"]);

    }, error => {
      this.invalidLogin = true;
    })


  }

}
