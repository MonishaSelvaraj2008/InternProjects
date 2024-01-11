import { Component } from '@angular/core';
import { IncrementService } from 'src/app/increment.service';

@Component({
  selector: 'app-payment-component',
  templateUrl: './payment-component.component.html',
  styleUrls: ['./payment-component.component.css']
})
export class PaymentComponentComponent {
   constructor(private service : IncrementService){
    
  }

  buttonIncrement()
    {
      this.service.incrementcounter();
    }
}
