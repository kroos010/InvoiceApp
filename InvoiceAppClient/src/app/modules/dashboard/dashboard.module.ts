import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DashboardRoutingModule } from './dashboard-routing.module';
import { DashboardComponent } from './dashboard.component';
import { SalesComponent } from './components/sales/sales.component';
import { EarningsComponent } from './components/earnings/earnings.component';
import { WalletComponent } from './components/wallet/wallet.component';
import { OpenInvoicesComponent } from './components/open-invoices/open-invoices.component';
import { AuthModule } from '../auth/auth.module';


@NgModule({
  declarations: [
    DashboardComponent,
    SalesComponent,
    EarningsComponent,
    WalletComponent,
    OpenInvoicesComponent
  ],
  imports: [
    CommonModule,
    DashboardRoutingModule
  ]
})
export class DashboardModule { }
