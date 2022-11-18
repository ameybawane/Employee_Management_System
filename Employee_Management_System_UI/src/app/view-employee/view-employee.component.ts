import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Employees } from '../models/Employees';
import { EmployeesService } from '../services/employees.service';

@Component({
  selector: 'app-view-employee',
  templateUrl: './view-employee.component.html',
  styleUrls: ['./view-employee.component.css']
})

export class ViewEmployeeComponent implements OnInit {
  viewEmpForm!: FormGroup;
  id!: number | string;
  viewEmpInfo: Employees = {
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
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private datePipe: DatePipe) { }

  ngOnInit(): void {
    const id = this.activatedRoute.snapshot.paramMap.get('id');

    if (id != null) {
      this.employeeService.getEmployeeById(id)
        .subscribe({
          next: (x) => {
            var dob = this.datePipe.transform(this.viewEmpInfo.dateOfBirth, 'yyyy/MM/dd');
            var isActive;
            if (this.viewEmpInfo.isActive = true) {
              isActive = "Active";
            } else {
              isActive = "InActive";
            }
            this.viewEmpInfo = x;
            this.viewEmpForm = this.fb.group({
              id: [this.viewEmpInfo.id],
              firstName: [this.viewEmpInfo.firstName],
              lastName: [this.viewEmpInfo.lastName],
              email: [this.viewEmpInfo.email],
              dateOfBirth: [dob],
              age: [this.viewEmpInfo.age],
              joinedDate: [this.viewEmpInfo.joinedDate],
              isActive: [isActive],
              departmentId: [this.viewEmpInfo.departmentId]
            });
          },
          error: (response) => {
            console.log(response);
          }
        });
    }
  }

  backToList() {
    this.router.navigate(['employees']);
  }

}