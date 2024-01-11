import { Component } from '@angular/core';
import { IncrementService } from 'src/app/increment.service';

@Component({
  selector: 'app-product-display',
  templateUrl: './product-display.component.html',
  styleUrls: ['./product-display.component.css']
})
export class ProductDisplayComponent {
  constructor(private service : IncrementService){
    
  }

  buttonIncrement()
    {
      this.service.incrementcounter();
    }

}
