import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Employees } from 'src/app/models/Employees';
import { EmployeesService } from 'src/app/services/employees.service';
import { Departments } from '../models/Departments';
import { isActive } from '../models/isActive';
import { DepartmentsService } from '../services/departments.service';

@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css']
})
export class AddEmployeeComponent implements OnInit {

  addEmpForm!: FormGroup;
  datePipe = new DatePipe(new Date().toString(), 'mediumDate');
  AllDepartmentId: Departments[] = [];
  isActive!: isActive[];
  
  constructor(private fb: FormBuilder,
    private employeeService: EmployeesService,
    private router: Router,
    private deptService: DepartmentsService) { }

  ngOnInit(): void {
    this.loadDept();
    this.isActive = [
      { name: "Active", isActive: true },
      { name: "inActive", isActive: false }];
    this.addEmpForm = this.fb.group({
      firstName: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(100)]],
      lastName: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(100)]],
      email: ['', [Validators.required, Validators.email]],
      dateOfBirth: ['', [Validators.required]],
      age: [''],
      joinedDate: [new Date()],
      isActive: ['', [Validators.required]],
      departmentId: ['', [Validators.required]]
    })
  }

  save(addEmpForm: Employees) {
    let dobYear = new Date(addEmpForm.dateOfBirth).getFullYear();
    let datetoYear = new Date().getFullYear();
    addEmpForm.joinedDate?.toISOString();
    let age = datetoYear - dobYear;
    addEmpForm.age = age;
    if (age >= 18 && age <= 58) {
      this.employeeService.addEmployee(addEmpForm).subscribe({
        next: (x) => {
          this.router.navigate(['/employees']);
          alert("Employee Added!");
        },
        error: (response) => {
          console.log(response);
        }
      });
    } else {
      alert("Incorrect age! Employees age is not correct!!");
    }
  }
  loadDept() {
    this.deptService.loadDepatrment().subscribe({
      next: (dept) => {
        this.AllDepartmentId = dept;
      },
      error: (response) => {
        console.log(response);
      }
    })
  }
}
