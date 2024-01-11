// checkout.component.ts
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CheckoutService } from '../checkout.service';
import { CheckoutModel } from '../Models/CheckoutModel';
import { Router } from '@angular/router';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.scss']
})
export class CheckoutComponent implements OnInit {
  checkoutForm!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private checkoutService: CheckoutService,
    private router: Router
  ) {}

  ngOnInit() {
    this.checkoutForm = this.fb.group({
      firstName: [
      '',[ 
      Validators.required,
      Validators.pattern('^[A-Z][a-z]+$'),
      Validators.minLength(3)]
    ],

      lastName: ['', [Validators.required,
        Validators.pattern('^[A-Z][a-z]+$'),
        Validators.minLength(3)
      ]],
        
      email: ['', [Validators.required,
        Validators.email,
        Validators.pattern('^(?!.*([A-Za-z0-9])\\1{2,}@)[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,}$')
    ]
      ],
      address: ['', [
      Validators.required,
      Validators.minLength(20)
    ]
    ],
      phoneNumber: ['', 
     [ Validators.required,
      Validators.minLength(10),
      Validators.maxLength(10),
      Validators.pattern('^[6-9]\\d{9}$')
    ]
    ],
      
    });
  }

  get f() {
    return this.checkoutForm.controls;
  }

  submitCheckoutForm() {
    if (this.checkoutForm.valid) {
      const user: CheckoutModel = this.checkoutForm.value;
      this.checkoutService.postCheckoutData(user)
        .then(() => {
          console.log('Data added successfully!!!');
        })
        .catch((error) => {
          console.error('Error adding data:', error);
        })
        .finally(() => {
          this.router.navigate(['/home']);
        });
    }
  }
}
