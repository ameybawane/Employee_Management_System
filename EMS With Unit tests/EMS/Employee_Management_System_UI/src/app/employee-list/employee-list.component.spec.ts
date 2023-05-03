import { ComponentFixture, TestBed } from '@angular/core/testing';
import { of } from 'rxjs';
import { EmployeesService } from '../services/employees.service';

import { EmployeeListComponent } from './employee-list.component';

describe('EmployeeListComponent', () => {
  let component: EmployeeListComponent;
  // let fixture: ComponentFixture<EmployeeListComponent>;
  let mockEmployeesService: any;
  // let employeeList;

  beforeEach(async () => {
    mockEmployeesService = jasmine.createSpyObj(['getAllEmployees']);
    component = new EmployeeListComponent(mockEmployeesService);
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should return component tittle', () => {
    expect(component.componentName).toBe("EmployeeListComponent");
  });

  it('should return all employees data', () => {
    let employeeList = [
      {
        id: 2, firstName: "amey", lastName: "b", email: "ab@mail.com", dateOfBirth: new Date(),
        age: 24, joinedDate: new Date(), isActive: true, departmentId: 1, departments: null
      },
      {
        id: 4, firstName: "kartik", lastName: "matte", email: "km@mail.com", dateOfBirth: new Date(),
        age: 25, joinedDate: new Date(), isActive: true, departmentId: 1, departments: null
      },
      {
        id: 1009, firstName: "rossy", lastName: "pam", email: "q@mail.com", dateOfBirth: new Date(),
        age: 19, joinedDate: new Date(), isActive: true, departmentId: 1003, departments: null
      },
      {
        id: 1008, firstName: "Lory", lastName: "pam", email: "l@p.com", dateOfBirth: new Date(),
        age: 21, joinedDate: new Date(), isActive: true, departmentId: 1006, departments: null
      }
    ];
    let response: any[] = [];

    mockEmployeesService.getAllEmployees.and.returnValue(of(employeeList));
    mockEmployeesService.getAllEmployees().subscribe((res: any[]) => { response = res });
    expect(response).toEqual(employeeList);
  });
});
