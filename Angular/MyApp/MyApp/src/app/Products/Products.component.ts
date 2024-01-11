import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ProductsService } from '../products.service';

@Component({
  selector: 'app-Products',
  templateUrl: './Products.component.html',
  styleUrls: ['./Products.component.css']
})
export class ProductsComponent implements OnInit {
  product:any="";
  constructor(private service : ProductsService)
  {

  }
  ngOnInit(): void {
    this.service.getProducts().subscribe(data=>{
      this.product=data;
      console.log(this.product);
    })

  }

}
