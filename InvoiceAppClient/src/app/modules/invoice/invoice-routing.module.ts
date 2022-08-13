import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from 'src/app/core/guard/auth.guard';
import { CreateInvoiceComponent } from './pages/create-invoice/create-invoice.component';

const routes: Routes = [
  {
    path: 'create',
    component: CreateInvoiceComponent, canActivate: [AuthGuard],
    children: [
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class InvoiceRoutingModule { }
