import { Injectable } from '@angular/core';
import { interval, Observable, startWith, Subscription } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationTokenManagerService {


  constructor(private authService: AuthService) { }

  isTokenAlmostExpired(): Observable<boolean> {

    const isExpired = new Observable<boolean>((observer) => {

      const timeInterval: Subscription = interval(5000).pipe(startWith(0)).subscribe((_) => {
        const currentDate = new Date()
        const expirationDate = new Date(this.authService.getTokenExpirationDate())
        const msBetweenDates = (expirationDate.getTime() - currentDate.getTime()) / (60 * 1000)

        // console.log('expirationDate', expirationDate)
        // console.log('currentDate', currentDate)
        // console.log('msBetweenDates', msBetweenDates)

        if (msBetweenDates < 5) {
          observer.next(true)
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
