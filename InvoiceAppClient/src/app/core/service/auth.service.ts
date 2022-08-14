import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { delay, map, Observable, switchMap, tap } from 'rxjs';
import { AuthenticationToken } from 'src/app/data/schema/AuthenticationToken';

type credentials = {
  'username': string,
  'password': string
}

type LoginResponse = {
  token: string,
  tokenExpiration: Date
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  login(credentials: credentials): Observable<any> {

    return this.http.post<LoginResponse>("https://localhost:7178/api/auth/login", credentials).pipe(
      tap((response) => {

        const token = response.token;
        const tokenExpiration = response.tokenExpiration;

        localStorage.setItem("jwt", token);
        localStorage.setItem("jwt_expiration", tokenExpiration.toString());

        return response;
      })
    );
  }

  renewToken(): Observable<any> {

    return this.http.post<AuthenticationToken>("https://localhost:7178/api/auth/RefreshToken", {}).pipe(
      tap((response) => {

        const token: AuthenticationToken = {
          token: response.token,
          tokenExpiration: response.tokenExpiration,
        }

        this.setTokens(token)

        return response;
      })
    );
  }

  getTokenExpirationDate() {
    const expirationDate = localStorage.getItem("jwt_expiration")

    if (expirationDate == null) {
      throw new Error('JWT token expiration date not set')
    }

    return new Date(expirationDate);
  }

  isTokenAlmostExpired(): boolean {
    return true;
  }

  private setTokens(authenticationToken: AuthenticationToken) {
    localStorage.setItem("jwt", authenticationToken.token);
    localStorage.setItem("jwt_expiration", authenticationToken.tokenExpiration.toString());
  }

  private removeTokens() {
    localStorage.removeItem('jwt')
    localStorage.removeItem('jwt_expiration')
  }

}
