import { ComponentFixture, TestBed } from '@angular/core/testing';
import { of } from 'rxjs';
import { Departments } from '../models/Departments';
import { DepartmentsService } from '../services/departments.service';
import { DepartmentListComponent } from './department-list.component';

describe('DepartmentListComponent', () => {
  let component: DepartmentListComponent;
  let fixture: ComponentFixture<DepartmentListComponent>;
  let mockDepartmentsService: any;
  let departmentsList: any;

  beforeEach(async () => {
    departmentsList = [
      { id: 1, name: 'JSE', isActive: true },
      { id: 1002, name: 'GT', isActive: true },
      { id: 1003, name: 'BA', isActive: true },
      { id: 1004, name: 'QA', isActive: true },
      { id: 1005, name: 'UI/UX', isActive: false },
      { id: 1006, name: 'P&OD', isActive: true }
    ];
    mockDepartmentsService = jasmine.createSpyObj(['deleteDepartment','loadDepatrment']);
    component = new DepartmentListComponent(mockDepartmentsService);
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should return component tittle', () => {
    expect(component.componentName).toBe("DepartmentListComponent");
  });

  it('should return all departments data', () => {
    let response: any[] = [];
    mockDepartmentsService.loadDepatrment.and.returnValue(of(departmentsList));
    mockDepartmentsService.loadDepatrment().subscribe((res: any[]) => { response = res });
    expect(response).toEqual(departmentsList);
  });

  // it('should remove specific department from departments list', () => {
  //   mockDepartmentsService.deleteDepartment.and.returnValue(of(true));
  //   component.departments = departmentsList;
  //   component.deleteDept(departmentsList[1]);
  //   expect(component.departments.length).toBe(5);
  // });

  
});
