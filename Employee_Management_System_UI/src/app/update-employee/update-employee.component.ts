import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Departments } from '../models/Departments';
import { Employees } from '../models/Employees';
import { isActive } from '../models/isActive';
import { DepartmentsService } from '../services/departments.service';
import { EmployeesService } from '../services/employees.service';

@Component({
  selector: 'app-update-employee',
  templateUrl: './update-employee.component.html',
  styleUrls: ['./update-employee.component.css']
})
export class UpdateEmployeeComponent implements OnInit {
  updateEmpForm!: FormGroup;
  id!: number | string;
  AllDepartmentId: Departments[] = [];
  isActive!: isActive[];
  editEmpInfo: Employees = {
    firstName: '',
    lastName: '',
    email: '',
    dateOfBirth: new Date(),
    age: 0,
    joinedDate: new Date(),
    isActive: false,
    departmentId: 0
  }

  constructor(private fb: FormBuilder,
    private employeeService: EmployeesService,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private deptService: DepartmentsService) { }

  ngOnInit(): void {
    this.loadDept();
    this.isActive = [
      { name: "Active", isActive: true },
      { name: "inActive", isActive: false }];
    const id = this.activatedRoute.snapshot.paramMap.get('id');
    if (id != null) {
      this.employeeService.getEmployeeById(id)
        .subscribe({
          next: (x) => {
            this.editEmpInfo = x;
            this.updateEmpForm = this.fb.group({
              id: [this.editEmpInfo.id, [Validators.required]],
              firstName: [this.editEmpInfo.firstName, [Validators.required, Validators.minLength(3), Validators.maxLength(100)]],
              lastName: [this.editEmpInfo.lastName, [Validators.required, Validators.minLength(3), Validators.maxLength(100)]],
              email: [this.editEmpInfo.email, [Validators.required, Validators.email]],
              dateOfBirth: [this.editEmpInfo.dateOfBirth, [Validators.required]],
              age: [this.editEmpInfo.age],
              joinedDate: [this.editEmpInfo.joinedDate],
              isActive: [this.editEmpInfo.isActive, [Validators.required]],
              departmentId: [this.editEmpInfo.departmentId, [Validators.required]]
            });
          },
          error: (response) => {
            console.log(response);
          }
        });
    }
  }


  UpdateEmployee(updateEmpForm: Employees) {
    this.employeeService.updateEmployee(updateEmpForm).subscribe({
      next: (x) => {
        this.router.navigate(['employees']);
      },
      error: (response) => {
        console.log(response);
      }
    });
  }

  loadDept() {
    this.deptService.loadDepatrment().subscribe({
      next: (dept) => {
        this.AllDepartmentId = dept;
      },
      error: (response) => {
        console.log(response);
      }
    });
  }
}
