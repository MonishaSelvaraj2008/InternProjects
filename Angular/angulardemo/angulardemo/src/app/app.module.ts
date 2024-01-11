import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BindingComponent } from './binding/binding.component';
import { EmployeeComponent } from './employee/employee.component';
import { GenderPipe } from './gender.pipe';
import { SizePipe } from './size.pipe';
import { TagColorComponent } from './tag-color/tag-color.component';
import { ApphighlighterDirective } from './apphighlighter.directive';
import { ButtonComponent } from './button/button.component';
import { LabelComponent } from './label/label.component';
import { ProductsModule } from './products/products.module';
import { MobileModule } from './mobile/mobile.module';
import { PaymentModule } from 'src/payment/payment.module';
import { HttpClientModule } from '@angular/common/http';
import { RegisterComponent } from './register/register.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { LoginComponent } from './login/login.component';
import { BookComponent } from './Book/Book.component';

@NgModule({
  declarations: [		
    AppComponent,
    BindingComponent,
    EmployeeComponent,
    GenderPipe,
    SizePipe,
    TagColorComponent,
    ApphighlighterDirective,
    ButtonComponent,
    LabelComponent,
    RegisterComponent,
      LoginComponent,
      BookComponent
   ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    FormsModule,
    AppRoutingModule,
    ProductsModule,
    MobileModule,
    PaymentModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
