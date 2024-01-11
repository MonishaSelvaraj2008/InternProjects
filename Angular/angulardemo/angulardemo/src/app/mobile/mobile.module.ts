import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MobileDIsplayComponent } from './mobile-display/mobile-display.component';



@NgModule({
  declarations: [
    MobileDIsplayComponent
  ],
  imports: [
    CommonModule
  ],
  exports:[MobileDIsplayComponent]
})
export class MobileModule { }
