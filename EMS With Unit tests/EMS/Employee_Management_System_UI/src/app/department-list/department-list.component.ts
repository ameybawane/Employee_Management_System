import { Component, OnInit } from '@angular/core';
import { Departments } from '../models/Departments';
import { DepartmentsService } from '../services/departments.service';

@Component({
  selector: 'app-department-list',
  templateUrl: './department-list.component.html',
  styleUrls: ['./department-list.component.css']
})
export class DepartmentListComponent implements OnInit {
  componentName = "DepartmentListComponent";

  departments: Departments[] = [];
  deptIdToDelete!: number;
  constructor(private departmentsService: DepartmentsService) { }

  ngOnInit(): void {
    this.departmentsService.loadDepatrment().subscribe({
      next: (x) => {
        this.departments = x;
        console.log(x);
      },
      error: (response) => {
        console.log(response);
      }
    });
  }

  deleteDept(id: number) {
    this.deptIdToDelete = id;
  }

  okDelete() {
    this.departmentsService.deleteDepartment(this.deptIdToDelete).subscribe({
      next: (x) => {
        alert("Employee deleted");
        window.location.reload();
      },
      error: (response) => {
        console.log(response);
        alert("Delete Failed! There is an Active employee in this department.");
      }
    })
  }
}
