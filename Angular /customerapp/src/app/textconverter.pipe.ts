import { Pipe, PipeTransform } from '@angular/core';

//  {{customer.firstName | textconvertor :'upper'}}
@Pipe({
  name: 'textconverter'
})
export class TextconverterPipe implements PipeTransform {

  transform(value: string, ...args: string[]): string {
    if(args[0] ==='upper') {
      return value.toUpperCase();
    } else {
      return value.toLowerCase();
    }
  }

}
