import { Injectable } from '@angular/core';
import { interval, Observable, startWith, Subscription } from 'rxjs';
import { AuthService } from './auth.service';

export type TokenExpirationStatus = {
  almostExpired: boolean,
  completelyExpired: boolean,
}

@Injectable({
  providedIn: 'root'
})
export class AuthenticationTokenManagerService {


  constructor(private authService: AuthService) { }

  // Todo: Seperate in other methods...
  isTokenAlmostExpired(): Observable<TokenExpirationStatus> {

    const isExpired = new Observable<TokenExpirationStatus>((observer) => {

      const status: TokenExpirationStatus = {
        almostExpired: false,
        completelyExpired: false
      }

      const timeInterval: Subscription = interval(5000).pipe(startWith(0)).subscribe((_) => {
        const currentDate = new Date()
        const expirationDate = new Date(this.authService.getTokenExpirationDate())
        const msBetweenDates = (expirationDate.getTime() - currentDate.getTime()) / (60 * 1000)

        // console.log('expirationDate', expirationDate)
        // console.log('currentDate', currentDate)
        // console.log('msBetweenDates', msBetweenDates)

        if (msBetweenDates <= 0) {
          status.completelyExpired = true
          observer.next(status)
        }
        if (msBetweenDates < 5) {
          status.almostExpired = true
          observer.next(status)
        }
        return {
          unsubscribe() {
            timeInterval.unsubscribe()
          }
        }
      })
    })

    return isExpired;
  }

  isTokenExpired(): boolean {
    return true;
  }
}
