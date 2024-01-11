// checkout.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CheckoutModel } from './Models/CheckoutModel';

@Injectable({
  providedIn: 'root'
})
export class CheckoutService {
  private apiUrl = 'http://localhost:5123/api/Checkout'; 

  constructor(private http: HttpClient) {}

  postCheckoutData(user: CheckoutModel): Promise<void> {
    const formData: FormData = new FormData();
    formData.append('firstName',user.firstName || '');
    formData.append('lastName', user.lastName || '');
    formData.append('email', user.email || '');
    formData.append('address', user.address|| '');
    formData.append('phoneNumber', user.phoneNumber.toString() || '');
    return this.http.post<void>(`${this.apiUrl}`, formData).toPromise();
  }
}
