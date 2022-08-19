import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { AuthModule } from '../modules/auth/auth.module';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { UnauthorizedInterceptor } from './interceptor/unauthorized.interceptor';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    SharedModule,
    AuthModule,
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: UnauthorizedInterceptor, multi: true }
  ]
})
export class CoreModule { }
