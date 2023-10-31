import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment.development';
import { Observable } from 'rxjs';
import { Employee } from '../interfaces/employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  private endpoint : string = environment.endpoint;
  private apiURL : string = this.endpoint + "employee";
  constructor(private http:HttpClient) { }

  //CRUD: Create, Read, Update, Delete

  create(model: Employee):Observable<Employee>{
    return this.http.post<Employee>(this.apiURL, model);
  }

  read():Observable<Employee[]>{
    return this.http.get<Employee[]>(this.apiURL);
  } 

  update(idEmployee: number, model: Employee):Observable<Employee>{
    return this.http.put<Employee>(`${this.apiURL}/${idEmployee}`, model);
  } 

  delete(idEmployee: number):Observable<void>{
    return this.http.delete<void>(`${this.apiURL}/${idEmployee}`);
  } 

}
