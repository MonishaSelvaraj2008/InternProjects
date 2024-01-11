import { Component } from '@angular/core';
import { IncrementService } from 'src/app/increment.service';

@Component({
  selector: 'app-mobile-display',
  templateUrl: './mobile-display.component.html',
  styleUrls: ['./mobile-display.component.css']
})
export class MobileDIsplayComponent {
  constructor(private service : IncrementService){
  }

     buttonIncrement()
    {
      this.service.incrementcounter();
    }
}
