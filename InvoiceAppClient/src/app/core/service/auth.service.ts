import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { delay, map, Observable, switchMap, tap } from 'rxjs';
import { AuthenticationToken } from 'src/app/data/schema/AuthenticationToken';
import { environment } from 'src/environments/environment';
import { ApiResult } from '../ApiResult';

type credentials = {
  'username': string,
  'password': string
}

type LoginResponse = {
  username: string,
  email: string,
  token: string,
  // tokenExpiration: Date
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  login(credentials: credentials): Observable<any> {

    return this.http.post<ApiResult<LoginResponse>>(`${environment.BASE_API_URL}/auth/authenticate`, credentials).pipe(
      tap((response) => {
        const token = response.result.token;

        // const tokenExpiration = response.result.tokenExpiration;
        let tokenExpiration = new Date();
        tokenExpiration.setDate(tokenExpiration.getDate() + 7);


        localStorage.setItem("jwt", token);
        localStorage.setItem("jwt_expiration", tokenExpiration.toString());

        return response;
      })
    );
  }

  renewToken(): Observable<any> {

    return this.http.post<AuthenticationToken>(`${environment.BASE_API_URL}/auth/RefreshToken`, {}).pipe(
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
