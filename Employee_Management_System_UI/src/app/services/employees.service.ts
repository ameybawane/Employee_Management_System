import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Employees } from '../models/Employees';

@Injectable({
  providedIn: 'root'
})
export class EmployeesService {

  baseApiUrl: string = environment.baseApiUrl; // referenced variable

  // to talk to external api need an http client
  constructor(private http: HttpClient) { }

  getAllEmployees(): Observable<Employees[]> {
    return this.http.get<Employees[]>(this.baseApiUrl + "employee");
  }

  addEmployee(emp: Employees): Observable<Employees> {
    return this.http.post<Employees>(this.baseApiUrl + "employee/post", emp);
  }

  getEmployeeById(id: string): Observable<Employees> {
    return this.http.get<Employees>(this.baseApiUrl + "employee/" + id);
  }

  updateEmployee(emp: Employees): Observable<Employees> {
    return this.http.put<Employees>(this.baseApiUrl + 'employee/' + emp.id, emp);
  }
}
