import { HttpClient } from '@angular/common/http';
import { of } from 'rxjs';
import { Employees } from '../models/Employees';
import { EmployeesService } from './employees.service';

describe('EmployeesService', () => {
    let employeesService: EmployeesService;
    let mockHttpClient: HttpClient;

    beforeEach(() => {
        employeesService = new EmployeesService(mockHttpClient);
    });

    it('should be created', () => {
        expect(employeesService).toBeTruthy();
    });

    it('should return all employees data', () => {
        let mockResponse = [
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
        spyOn(employeesService, 'getAllEmployees').and.returnValue(of(mockResponse));
        employeesService.getAllEmployees().subscribe(res => { response = res });
        expect(response).toEqual(mockResponse);
    });

    it('should return specific employees data of given id', () => {
        let mockResponse: any = [
            // {
            //     id: 2, firstName: "amey", lastName: "b", email: "ab@mail.com", dateOfBirth: new Date(),
            //     age: 24, joinedDate: new Date(), isActive: true, departmentId: 1, departments: null
            // }
            {
                id: 2, firstName: "amey", lastName: "b", email: "ab@mail.com", dateOfBirth: "1998-11-26T00:00:00",
                age: 24, joinedDate: "2022-07-04T00:00:00", isActive: true, departmentId: 1, departments: null
            }
        ];
        let id = 2;
        let Response: any;
        spyOn(employeesService, 'getEmployeeById').and.returnValue(of(mockResponse));
        employeesService.getEmployeeById(id).subscribe(res => { Response = res });
        expect(Response).toEqual(mockResponse);
    });

    it('should add employee', () => {
        let employee: Employees = {
            firstName: '',
            lastName: '',
            email: '',
            dateOfBirth: new Date(),
            age: 0,
            joinedDate: new Date,
            isActive: false,
            departmentId: 0
        }
        let response: any;
        spyOn(employeesService, 'addEmployee').and.returnValue(of(employee));
        employeesService.addEmployee(employee).subscribe(res => { response = res });
        expect(response).toEqual(employee);
    });

    it('should update existing employee data', () => {
        let employee: Employees = {
            firstName: '',
            lastName: '',
            email: '',
            dateOfBirth: new Date(),
            age: 0,
            joinedDate: new Date,
            isActive: false,
            departmentId: 0
        }
        let response: any;
        spyOn(employeesService, 'updateEmployee').and.returnValue(of(employee));
        employeesService.updateEmployee(employee).subscribe(res => { response = res });
        expect(response).toEqual(employee);
    });
});
