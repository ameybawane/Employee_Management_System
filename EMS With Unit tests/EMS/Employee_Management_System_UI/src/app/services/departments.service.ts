import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Departments } from '../models/Departments';

@Injectable({
  providedIn: 'root'
})
export class DepartmentsService {

  baseApiUrl: string = environment.baseApiUrl; // referenced variable

  // to talk to external api need an http client
  constructor(private http: HttpClient) { }

  loadDepatrment(): Observable<Departments[]> {
    return this.http.get<Departments[]>(this.baseApiUrl + "\departments");
  }

  getDepartmentById(id: string | any): Observable<Departments> {
  //getDepartmentById(id: string | any): Observable<any> {
    return this.http.get<Departments>(this.baseApiUrl + "departments/" + id);
  }
  
  deleteDepartment(id: number | any): Observable<Departments> {
  //deleteDepartment(id: number | any): Observable<any> {
    return this.http.delete<Departments>(this.baseApiUrl + "departments/" + id);
  }
}
