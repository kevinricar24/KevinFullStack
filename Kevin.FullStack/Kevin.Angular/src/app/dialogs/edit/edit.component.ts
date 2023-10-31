import { Component, OnInit, Inject } from '@angular/core';

import { FormBuilder,FormGroup,Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

import { MatSnackBar } from '@angular/material/snack-bar';

import { MAT_DATE_FORMATS } from '@angular/material/core';

import * as moment from 'moment';

import { Department } from 'src/app/interfaces/department';
import { Employee } from 'src/app/interfaces/employee';
import { DepartmentService } from 'src/app/services/department.service';
import { EmployeeService } from 'src/app/services/employee.service';

export const MY_DATE_FORMATS ={
  parse:{
    dateInput:'DD/MM/YYYY',
  },
  display:{
    dateInput:'DD/MM/YYYY',
    monthYearLabel:'MMMM YYYY',
    dateA11yLabel:'LL',
    monthYearA11yLabel:'MMMM YYYY'
  }
}

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.sass'],
  providers :[{provide: MAT_DATE_FORMATS, useValue: MY_DATE_FORMATS}]
})
export class EditComponent implements OnInit {

  formEmployee: FormGroup;
  accionTitle: string = "New";
  accionButton: string = "Guardar";
  DepartmentList: Department[] = []

  constructor(
    private referenceDialog: MatDialogRef<EditComponent>,
    private fb:FormBuilder,
    private _snackBar: MatSnackBar,
    private _departmentService:DepartmentService,
    private _employeeService:EmployeeService,
    @Inject(MAT_DIALOG_DATA) public employeeData:Employee
  ){

    this.formEmployee = this.fb.group({
      fullName:['',Validators.required],
      departmentId:['',Validators.required],
      salary:['',Validators.required],
      contractDate:['',Validators.required]
    })

    this._departmentService.getList().subscribe({
      next:(data)=>{
        this.DepartmentList = data;
      },error:(e)=>{}
    })


  }

  ShowAlert(msg: string, accion: string) {
    this._snackBar.open(msg, accion,{
      horizontalPosition:"end",
      verticalPosition:"top",
      duration:3000
    });
  }

  addEditEmployee(){
    console.log(this.formEmployee.value)
  
    const model:Employee={
      idEmployee:0,
      fullname: this.formEmployee.value.fullName,
      idDepartment: this.formEmployee.value.departmentId,
      salary: this.formEmployee.value.salary,
      contractDate: moment(this.formEmployee.value.contractDate).format("DD/MM/YYYY")
    }
  
    if(this.employeeData == null)
    {
  
      this._employeeService.create(model).subscribe({
        next:(data)=> {
          this.ShowAlert("Employee created","Ok");
          this.referenceDialog.close("created")
        },error:(e)=>{
          this.ShowAlert("Error creating Employee","Error");
        }
      })
  
    }
    else
    {
      this._employeeService.update(this.employeeData.idEmployee, model).subscribe({
        next:(data)=> {
          this.ShowAlert("Employee updated","Ok");
          this.referenceDialog.close("updated")
        },error:(e)=>{
          this.ShowAlert("Error updating Employee","Error");
        }
      })
    }
  }
  
  ngOnInit(): void {
    if(this.employeeData){
      this.formEmployee.patchValue({
        fullName:this.employeeData.fullname,
        departmentId:this.employeeData.idDepartment,
        salary:this.employeeData.salary,
        contractDate:moment(this.employeeData.contractDate,"DD/MM/YYYY")
      })
  
      this.accionTitle = "Edit";
      this.accionButton = "Update";
    }
  }

}
