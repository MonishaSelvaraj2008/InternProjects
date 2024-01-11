import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './Home/Home.component';
import { LoginComponent } from './Login/Login.component';
import { ProductsComponent } from './Products/Products.component';
import { ContactusComponent } from './Contactus/Contactus.component';
import { ProductdetailedComponent } from './productdetailed/productdetailed.component';
import{HttpClientModule} from '@angular/common/http';


@NgModule({
  declarations: [
    AppComponent,
      HomeComponent,
      LoginComponent,
      ProductsComponent,
      ContactusComponent,
      ProductdetailedComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
