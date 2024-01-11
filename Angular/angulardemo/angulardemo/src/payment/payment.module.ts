import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaymentComponentComponent } from './payment-component/payment-component.component';



@NgModule({
  exports:[PaymentComponentComponent],
  declarations: [
    PaymentComponentComponent
  ],
  imports: [
    CommonModule
  ]
})
export class PaymentModule { }
