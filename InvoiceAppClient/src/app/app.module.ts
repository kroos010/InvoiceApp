import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthLayoutComponent } from './layouts/auth-layout/auth-layout.component';
import { DashboardLayoutComponent } from './layouts/dashboard-layout/dashboard-layout.component';
import { JwtModule } from '@auth0/angular-jwt';

export const tokenGetter = () => {
  return localStorage.getItem("jwt");
}

@NgModule({
  declarations: [
    AppComponent,
    AuthLayoutComponent,
    DashboardLayoutComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ["localhost:7178"],
        disallowedRoutes: []
      }
    }),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
