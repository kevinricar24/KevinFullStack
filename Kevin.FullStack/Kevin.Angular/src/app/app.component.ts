import {AfterViewInit, Component, OnInit, ViewChild} from '@angular/core';
import {MatPaginator } from '@angular/material/paginator';
import {MatTableDataSource } from '@angular/material/table';

import { Employee } from './interfaces/employee';
import { EmployeeService } from './services/employee.service';

import {MatDialog, MatDialogModule} from '@angular/material/dialog';
import { EditComponent } from './dialogs/edit/edit.component';
import { DeleteComponent } from './dialogs/delete/delete.component';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.sass'],
})
export class AppComponent implements AfterViewInit, OnInit {
  title = 'Kevin.Angular';

  displayedColumns: string[] = ['FullName', 'Department', 'Salary', 'ContractDate','Actions'];
  dataSource = new MatTableDataSource<Employee>();

  constructor(
    private _employeeService: EmployeeService, 
    public dialog: MatDialog,
    private _snackBar: MatSnackBar
    ){}

  ngOnInit(): void {
    this.ShowEmployee();
  }

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  applyFilter(event:Event){
    const filterValue=(event.target as HTMLInputElement).value;
    this.dataSource.filter=filterValue.trim().toLocaleLowerCase();
  }

  ShowEmployee(){
    this._employeeService.read().subscribe({
      next:(dataResponse) => {
        this.dataSource.data = dataResponse;
      },error:(e) => {}
    })
  }

  NewEmployeeDialog() {
    this.dialog.open(EditComponent,{
      disableClose:true,
      width:"350px"
    }).afterClosed().subscribe(result=>{
      if(result === "created"){
        this.ShowEmployee();
      }
    })
  }

  EditEmployeeDialog(employeeData: Employee) {
    this.dialog.open(EditComponent,{
      disableClose:true,
      width:"350px",
      data:employeeData
    }).afterClosed().subscribe(result=>{
      if(result === "updated"){
        this.ShowEmployee();
      }
    })
  }


  ShowAlert(msg: string, accion: string) {
    this._snackBar.open(msg, accion,{
      horizontalPosition:"end",
      verticalPosition:"top",
      duration:3000
    });
  }

  DeleteEmployeeDialog(employeeData: Employee)
  {
    this.dialog.open(DeleteComponent,{
      disableClose:true,
      data:employeeData
    }).afterClosed().subscribe(result=>{
      if(result === "delete"){
        this._employeeService.delete(employeeData.idEmployee).subscribe({
          next:(data) => {
            this.ShowAlert("Employee deleted","OK")
            this.ShowEmployee();
          },error:(e)=>{console.log(e)} 
        });
      }
    })
  }


}
