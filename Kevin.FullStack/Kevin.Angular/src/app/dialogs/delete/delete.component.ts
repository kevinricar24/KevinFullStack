import { Component, OnInit, Inject } from '@angular/core';

import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

import { Employee } from 'src/app/interfaces/employee';

@Component({
  selector: 'app-delete',
  templateUrl: './delete.component.html',
  styleUrls: ['./delete.component.sass']
})
export class DeleteComponent implements OnInit{

  constructor(
    private referenceDialog: MatDialogRef<DeleteComponent>,
    @Inject(MAT_DIALOG_DATA) public employeeData:Employee
  ){}

  ngOnInit(): void {    
  }

  delete_Confirm(){
    if(this.employeeData){
      this.referenceDialog.close("delete")
    }
  }
}
