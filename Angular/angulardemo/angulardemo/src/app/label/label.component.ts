import { Component } from '@angular/core';
import { VisitorcountService } from '../visitorcount.service'; 

@Component({
  selector: 'app-label',
  templateUrl: './label.component.html',
  styleUrls: ['./label.component.css']
})
export class LabelComponent {
  constructor(private service: VisitorcountService){

  }
  ngOnInit(){

  }
  incrementLabelCount()
  {
    this.service.incrementVisitorCount;
  }
  

}
