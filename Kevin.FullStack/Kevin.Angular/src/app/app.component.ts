import {AfterViewInit, Component, OnInit, ViewChild} from '@angular/core';
import {MatPaginator } from '@angular/material/paginator';
import {MatTableDataSource } from '@angular/material/table';

import { Employee } from './interfaces/employee';
import { EmployeeService } from './services/employee.service';

import {MatDialog, MatDialogModule} from '@angular/material/dialog';

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
    public dialog: MatDialog
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
        console.log(dataResponse);
        this.dataSource.data = dataResponse;
      },error:(e) => {}
    })
  }

}
