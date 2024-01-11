import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './auth.guard';
import { ContactusComponent } from './Contactus/Contactus.component';
import { HomeComponent } from './Home/Home.component';
import { LoginComponent } from './Login/Login.component';
import { ProductdetailedComponent } from './productdetailed/productdetailed.component';
import { ProductsComponent } from './Products/Products.component';


const routes: Routes = [
  {
    path:'home',
    component: HomeComponent
  },
  {
    path:'Products',
    component:ProductsComponent,

    children:[
      {
        path:':check',
        component:ProductdetailedComponent,
      }
    ]

  },
  {
    path:'Login',
    component:LoginComponent
  },
  {
    path:'ContactUs',
    component:ContactusComponent
  },
  {
    path:"**",
    component:HomeComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
