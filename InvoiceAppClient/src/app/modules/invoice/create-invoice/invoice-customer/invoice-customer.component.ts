import { Component, ElementRef, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
type Customer = {
  id: number
  companyName: string,
  Contactname: string,
  PhoneNumber: string,
  EmailAddress: string,
}

@Component({
  selector: 'app-invoice-customer',
  templateUrl: './invoice-customer.component.html',
  styleUrls: ['./invoice-customer.component.scss'],
  host: {
    '(document:click)': 'onComponentClickOut($event)',
  },
})
export class InvoiceCustomerComponent implements OnInit {

  @Output() customer = new EventEmitter<Customer>();

  onSearching: boolean = false
  customers: Customer[]
  selectedCustomer?: Customer

  constructor(private _eref: ElementRef) {

    this.customers = [
      {
        id: 5,
        companyName: 'Kevin Enterprise',
        Contactname: 'Kevin Kroos',
        PhoneNumber: "0613000842",
        EmailAddress: "kevinkroos@gmail.com"

      },
      {
        id: 26,
        companyName: 'Zooki B.V.',
        Contactname: 'rafed Razooki',
        PhoneNumber: "0655555554",
        EmailAddress: "rafed@gmail.com"
      },
    ]
  }

  ngOnInit(): void {
  }

  onSearchingClicked(event: any) {
    // this.onSearching = !this.onSearching
    this.onSearching = true;
  }


  onSelectedCustomerClicked(customer: Customer) {
    this.customer.emit(customer);
    this.onSearching = false;
  }

  private onComponentClickOut(event: any) {
    if (!this._eref.nativeElement.contains(event.target)) { // or some similar check
      this.onSearching = false;
    }
  }

}
