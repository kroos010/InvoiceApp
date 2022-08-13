import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'customerInvoiceSearch'
})
export class CustomerInvoiceSearchPipe implements PipeTransform {

  transform(value: unknown, ...args: unknown[]): unknown {
    return null;
  }

}
