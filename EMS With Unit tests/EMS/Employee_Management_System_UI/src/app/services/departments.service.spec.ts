import { HttpClient } from '@angular/common/http';
import { of } from 'rxjs';
import { Departments } from '../models/Departments';
import { DepartmentsService } from './departments.service';

describe('DepartmentsService', () => {
  let departmentsService: DepartmentsService;
  let mockHttpClient: HttpClient;

  beforeEach(() => {
    departmentsService = new DepartmentsService(mockHttpClient);
  });

  it('should be created', () => {
    expect(departmentsService).toBeTruthy();
  });

  it('should return all departments data', () => {
    //arrange
    let mockResponse = [
      { id: 1, name: 'JSE', isActive: true },
      { id: 1002, name: 'GT', isActive: true },
      { id: 1003, name: 'BA', isActive: true },
      { id: 1004, name: 'QA', isActive: true },
      { id: 1005, name: 'UI/UX', isActive: false },
      { id: 1006, name: 'P&OD', isActive: true }
    ];
    let response: any[] = [];
    //act
    spyOn(departmentsService, 'loadDepatrment').and.returnValue(of(mockResponse));
    departmentsService.loadDepatrment().subscribe(res => { response = res });
    //assert
    expect(response).toEqual(mockResponse);
  });

  // it('should return specific department from department list for specific id ', () => {
  //   let mockResponse = [
  //     { id: 1, name: 'JSE', isActive: true },
  //     { id: 1002, name: 'GT', isActive: true },
  //     { id: 1003, name: 'BA', isActive: true }
  //   ];
  //   let response: any[] = [];
  //   spyOn(departmentsService, 'getDepartmentById').and.returnValue(of(mockResponse));
  //   departmentsService.getDepartmentById(1003).subscribe(res => { response = res });
  //   expect(Response).toEqual(mockResponse);
  // });

  // it('should remove specific department from departments list', () => {
  //   let mockResponse = [
  //     { id: 1004, name: 'QA', isActive: true },
  //     { id: 1005, name: 'UI/UX', isActive: false }
  //   ];
  //   let response: any[] = [];
  //   spyOn(departmentsService, 'deleteDepartment').and.returnValue(of(mockResponse));
  //   departmentsService.deleteDepartment(1005).subscribe(res => { response = res });
  //   expect(Response).toEqual(mockResponse);
  // });
});
