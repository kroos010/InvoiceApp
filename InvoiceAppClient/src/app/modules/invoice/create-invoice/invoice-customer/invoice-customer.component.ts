import { Component, ElementRef, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { Debtor } from 'src/app/data/schema/Debtor';

@Component({
  selector: 'app-invoice-customer',
  templateUrl: './invoice-customer.component.html',
  styleUrls: ['./invoice-customer.component.scss'],
  host: {
    '(document:click)': 'onComponentClickOut($event)',
  },
})
export class InvoiceCustomerComponent implements OnInit {

  @Output() customer = new EventEmitter<Debtor>();

  onSearching: boolean = false
  customers: Debtor[] | unknown
  selectedCustomer?: Debtor

  public searchFilter: any = '';
  query: any = '';

  constructor(private _eref: ElementRef) {

    this.customers = [
      {
        Id: 'D01',
        FirstName: 'Kevin',
        LastName: 'Kroos',
        CompanyName: 'Kevin Enterprise',
        Address: 'High-Tech street',
        HouseNumber: '16',
        ZipCode: '3343 DT',
        City: 'Hendrik-Ido-Ambacht',
        Country: 'Nederland',
        Email: 'kevin@gmail.com',
      },
      {
        Id: 'D02',
        FirstName: 'Rafed',
        LastName: 'Razooki',
        CompanyName: 'Zooki Enterprise',
        Address: 'Maasstraat',
        HouseNumber: '36',
        ZipCode: '5684 HK',
        City: 'Maassluis',
        Country: 'Nederland',
        Email: 'rafed@gmail.com',
      },
      {
        Id: 'D01',
        FirstName: 'Jean',
        LastName: 'Rukundo',
        CompanyName: 'Nano Media',
        Address: 'Heyemanstraat',
        HouseNumber: '35',
        ZipCode: '4632 YG',
        City: 'Rotterdam',
        Country: 'Nederland',
        Email: 'jean@gmail.com',
      },
    ]
  }

  ngOnInit(): void {
  }

  onSearchingClicked(event: any) {
    this.onSearching = true;
  }


  onSelectedCustomerClicked(customer: Debtor) {
    this.selectedCustomer = customer;
    this.customer.emit(this.selectedCustomer);
    this.onSearching = false;
  }

  onDeselect() {
    this.selectedCustomer = undefined
    this.customer.emit(undefined);
  }

  private onComponentClickOut(event: any) {
    if (!this._eref.nativeElement.contains(event.target)) {
      this.onSearching = false;
    }
  }

}
