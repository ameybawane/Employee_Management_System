import { Pipe, PipeTransform } from '@angular/core';
import { Employees } from '../models/Employees';

@Pipe({
  name: 'searchEmployee'
})
export class SearchEmployeePipe implements PipeTransform {
  transform(value: any, ...args: any[]): any {
    let filterBy = args[0].toLocaleLowerCase();
    let EmployeeName = value.filter(
      (Employee: Employees) => Employee.firstName.toLocaleLowerCase().includes(filterBy)
    );

    return EmployeeName;
  }
}
