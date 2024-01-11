import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductsService } from '../products.service';

@Component({
  selector: 'app-productdetailed',
  templateUrl: './productdetailed.component.html',
  styleUrls: ['./productdetailed.component.css']
})
export class ProductdetailedComponent implements OnInit {
product:any="";
searchFor:any="";
finalProduct:any="";

  constructor(private service:ProductsService, private route:ActivatedRoute) { }

  ngOnInit() {
    this.service.getProducts().subscribe(data=>{
      this.product=data;


        this.route.params.subscribe(paramdata=>{
          this.searchFor=paramdata['check'];


          for(let item of this.product){
            if(item.title==this.searchFor){

                this.finalProduct=item;
                break;


            }


        }
        })
      })
  }

}

