import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductDisplayComponent } from './product-display/product-display.component';



@NgModule({
  declarations: [
    ProductDisplayComponent
  ],
  imports: [
    CommonModule
  ],
  exports:[ProductDisplayComponent]
})
export class ProductsModule { }
