import { Component } from '@angular/core';
import { ProductService } from './product.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Angular demo project';
  //card='../assests/mastercard.png';
  choice=false;
  wm="Welcome";
  parentVariable:any="Any questions check with me";
  childMessageVariable:any="";
  show()
  {
    alert('Button is clicked');
  }
  changeWm()
  {
    this.wm="Changing the content";
  }
  constructor(private service: ProductService)
  {
    this.service.getProducts().subscribe()
    {
      console.log();
    }
  }
}
