import { Component } from '@angular/core';

@Component({
  selector: 'app-tag-color',
  templateUrl: './tag-color.component.html',
  styleUrls: ['./tag-color.component.css']
})
export class TagColorComponent {
  role:any="Please select the role";

  status:boolean=true;
  
  ngOnInit(){

  }
  toggleCase()
  {
    this.status=!this.status;
  }
}
