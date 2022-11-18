import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'boolToText'
})
export class BoolToTextPipe implements PipeTransform {

  transform(value: any) {
    return value ? 'Active' : 'InActive';
  }

}
