import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddEmployeeComponent } from './add-employee/add-employee.component';
import { DepartmentListComponent } from './department-list/department-list.component';
import { EmployeeListComponent } from './employee-list/employee-list.component';
import { UpdateEmployeeComponent } from './update-employee/update-employee.component';
import { ViewEmployeeComponent } from './view-employee/view-employee.component';

const routes: Routes = [
  {
    path: '', component: EmployeeListComponent
  },
  {
    path: 'employees', component: EmployeeListComponent
  },
  {
    path: 'employees/add', component: AddEmployeeComponent
  },
  {
    path: 'employees/edit/:id', component: UpdateEmployeeComponent
  },
  {
    path: 'employees/view/:id', component: ViewEmployeeComponent
  },
  {
    path: 'departments', component: DepartmentListComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
