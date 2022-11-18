import { Component, OnInit } from '@angular/core';
import { Employees } from 'src/app/models/Employees';
import { EmployeesService } from 'src/app/services/employees.service';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {

  employees: Employees[] = [];
  employeeName: string = "";

  constructor(private employeesService: EmployeesService) { }

  ngOnInit(): void {

    this.employeesService.getAllEmployees().subscribe({
      next: (x) => {
        this.employees = x;
        console.log(x);
      },
      error: (response) => {
        console.log(response);
      }
    });
  }
}
