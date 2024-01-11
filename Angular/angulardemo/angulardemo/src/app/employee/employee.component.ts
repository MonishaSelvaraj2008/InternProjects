import { Component } from '@angular/core';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent {
  employee:any=[
    {
      empid:1,
      empname:"Monisha",
      age: 21
    },
    {
      empid:2,
      empname:"Veda",
      age: 21
    },
    {
      empid:3,
      empname:"Sandhiya",
      age: 20
    },
    {
      empid:4,
      empname:"Abishek",
      age: 29
    }
  ]
  todayDate = new Date;
    
  
  status:boolean=true
    constructor()
    {}
  toggleCase()
  {
    
  }
}
