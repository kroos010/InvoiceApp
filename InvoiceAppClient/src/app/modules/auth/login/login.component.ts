import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { delay } from 'rxjs';
import { AuthService } from 'src/app/core/service/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  submitted: boolean;
  invalidLogin: boolean;
  showLoading: boolean = false;
  loginForm!: FormGroup;

  constructor(private router: Router, private formBuilder: FormBuilder, private http: HttpClient, private authService: AuthService) {
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
    this.showLoading = true;
    const formResult = this.loginForm.value;

    const loginResult = this.authService.login({
      'username': formResult.name,
      'password': formResult.password
    }).subscribe({
      next: (result) => {
        this.showLoading = false;
        this.invalidLogin = false;
        this.router.navigate(["/"])
      },
      error: (e) => {
        this.showLoading = false;
        this.invalidLogin = true;
      },
    });

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
