import { Component, OnInit } from '@angular/core';
import { AppComponent } from '../app.component';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RegistrationService } from '../Services/registration.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss'],
})
export class SignupComponent implements OnInit {
  RegisterForm!: FormGroup;
  Userdata: any;
  DataAlredyAdded: boolean = false;
  constructor(
    private app: AppComponent,
    private formbuilder: FormBuilder,
    private api: RegistrationService,
    private router: Router
  ) {
    this.RegisterForm = formbuilder.group({
      name: formbuilder.control('', [
        Validators.required,
        Validators.pattern('^[A-Z][a-z]+$'),
        Validators.minLength(3)
    ]),
      lastname: formbuilder.control('', [
        Validators.required,
        Validators.pattern('^[A-Z][a-z]+$'),
        Validators.minLength(3)
      ]),
      mobilenumber: formbuilder.control('', [
        Validators.required,
        Validators.minLength(10),
        Validators.maxLength(10),
        Validators.pattern('^[6-9]\\d{9}$')
      ]),
      DOB: formbuilder.control('', [Validators.required]),
      email: formbuilder.control('', [
        Validators.required,
        Validators.email,
        Validators.pattern('^(?!.*([A-Za-z0-9])\\1{2,}@)[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,}$')
      ]),
      password: formbuilder.control('', [
        Validators.required,
        Validators.minLength(8),
        Validators.pattern(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/)

      ]),
    });
  }

  Image: any;
  ngOnInit() {
    this.Image = this.app.images[2];
    this.getAllproduct();
  }
  characters = 'ABCDEFGHIJKLMnopqrstuvwxyz0123456789NOPQRSTUVWXYZabcdefghijklm';
  result: any = '';
  onSubmit() {
    this.getAllproduct();
    this.characters +=
      this.RegisterForm.value.name +
      this.RegisterForm.value.lastname +
      this.RegisterForm.value.mobilenumber +
      this.RegisterForm.value.DOB +
      this.RegisterForm.value.email +
      this.RegisterForm.value.password;

    for (let k = 0; k < 5; k++) {
      for (let i = 0; i < 100; i++) {
        this.result += this.characters.charAt(Math.floor(Math.random() * 100));
      }
    }
    console.log(this.result.length);
    if (this.Userdata != null) {
      for (var i = 0; i < this.Userdata.length; i++) {
        if (
          this.Userdata[i].email == this.RegisterForm.value.email ||
          this.Userdata[i].mobilenumber ==
            this.RegisterForm.value.mobilenumber ||
          this.Userdata[i].UserId == this.result
        ) {
          this.DataAlredyAdded = true;
          break;
        }
      }

      if (this.DataAlredyAdded == false) {
        let data = {
          name: this.RegisterForm.value.name,
          lastname: this.RegisterForm.value.lastname,
          mobilenumber: this.RegisterForm.value.mobilenumber,
          email: this.RegisterForm.value.email,
          DOB: this.RegisterForm.value.DOB,
          password: this.RegisterForm.value.password,
          UserId: this.result,
        };

        this.api.postUserdata(data).subscribe({
          next: (res) => {
            this.RegisterForm.reset();
          },
          error: (err) => {
            alert('Error while adding the product');
            console.log(err);
          },
        });

        this.router.navigate(['/Login']);
      } else {
        this.DataAlredyAdded = false;
        alert('Data Alredy Added');
      }
    }
  }

  getAllproduct() {
    this.api.getUserdata().subscribe({
      next: (res) => {
        this.Userdata = res;
      },
      error: (err) => {
        alert('Error');
      },
    });
  }
}
