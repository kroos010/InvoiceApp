import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { InvoiceRoutingModule } from './invoice-routing.module';
import { CreateInvoiceComponent } from './create-invoice/create-invoice.component';
import { InvoiceCustomerComponent } from './create-invoice/invoice-customer/invoice-customer.component';


@NgModule({
  declarations: [
    CreateInvoiceComponent,
    InvoiceCustomerComponent,
  ],
  imports: [
    CommonModule,
    InvoiceRoutingModule
  ]
})
export class InvoiceModule { }
