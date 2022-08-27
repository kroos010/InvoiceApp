import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {

  signupForm: FormGroup;
  submitted: boolean;


  constructor(private router: Router, private formBuilder: FormBuilder, private http: HttpClient) {
    this.submitted = false;
    this.signupForm = this.formBuilder.group({
      firstname: ['', Validators.required],
      lastname: ['', Validators.required],
      email: ['', Validators.compose(
        [Validators.required, Validators.email])],
      password: ['', Validators.required],
    });
  }

  ngOnInit(): void {
  }

  onSubmit() {
    const formResult = this.signupForm.value;

    const credentials = {
      'firstname': formResult.firstname,
      'lastname': formResult.lastname,
      'email': formResult.email,
      'password': formResult.password
    }

    this.http.post("https://localhost:7248/api/auth/signup", credentials).subscribe(response => {
      this.submitted = true;
      this.router.navigate(["/"])
    }, error => {
      if (error.error.some((e: any) => e.code === 'DuplicateUserName')) {
        this.signupForm.controls['email'].setErrors({ 'DuplicateUserName': true });
      }
      this.submitted = true;
    });
  }

  public errorHandling = (control: string, error: string) => {
    if ((this.submitted && this.signupForm.controls[control].invalid) || this.signupForm.controls[control].invalid && (this.signupForm.controls[control].dirty || this.signupForm.controls[control].touched)) {
      return this.signupForm.controls[control].hasError(error);
    }

    return false;
  }

}
