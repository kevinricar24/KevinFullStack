import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment.development';
import { Observable } from 'rxjs';
import { Department } from '../interfaces/department';


@Injectable({
  providedIn: 'root'
})
export class DepartmentService {

  private endpoint : string = environment.endpoint;
  private apiURL : string = this.endpoint + "department";
  constructor(private http:HttpClient) { }

  getList():Observable<Department[]>{
    return this.http.get<Department[]>(this.apiURL)
  } 


}
