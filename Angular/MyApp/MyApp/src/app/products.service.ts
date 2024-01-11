import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  constructor(private client:HttpClient) { }

  getProducts()
  {
    return this.client.get("http://localhost:3000/product");
}
}
