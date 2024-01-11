import { Component } from '@angular/core';
import { VisitorcountService } from '../visitorcount.service';

@Component({
  selector: 'app-button',
  templateUrl: './button.component.html',
  styleUrls: ['./button.component.css']
})
export class ButtonComponent {

  constructor(private service: VisitorcountService){

  }
  ngOnInit(){

  }
  incrementButtonCount()
  {
    this.service.incrementVisitorCount;
  }

 }
