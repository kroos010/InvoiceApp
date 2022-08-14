import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { delay, map, Observable, switchMap } from 'rxjs';

type credentials = {
  'username': string,
  'password': string
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  login(credentials: credentials): Observable<any> {

    return this.http.post("https://localhost:7178/api/auth/login", credentials).pipe(
      map((response: any) => {

        const token = (<any>response).token;
        localStorage.setItem("jwt", token);

        return response;
      })
    );
  }
}
