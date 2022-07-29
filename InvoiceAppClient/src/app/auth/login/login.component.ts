import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  submitted: boolean;
  invalidLogin: boolean;
  loginForm!: FormGroup;


  // this.loginForm = FormGroup({

  //   name: new FormControl(this.loginForm.name, [
  //     Validators.required,
  //   ]),


  //   // name: '',
  //   // password: ''
  // });

  constructor(private router: Router, private formBuilder: FormBuilder, private http: HttpClient) {
    this.submitted = false;
    this.invalidLogin = false;
  }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      name: ['', Validators.required],
      password: ['', [Validators.required]],
    });
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

    this.submitted = true;
  }

  public errorHandling = (control: string, error: string) => {
    if ((this.submitted && this.loginForm.controls[control].invalid) || this.loginForm.controls[control].invalid && (this.loginForm.controls[control].dirty || this.loginForm.controls[control].touched)) {
      return this.loginForm.controls[control].hasError(error);
    }

    return false;
  }

  get loginFormControl() {
    return this.loginForm.controls;
  }
}
