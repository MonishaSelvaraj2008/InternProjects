import { Component } from '@angular/core';
import { UserService } from '../user.service';
import { FormBuilder, FormGroup, FormControl, Validators} from '@angular/forms';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styles:[`input.ng-invalid{border:5px solid red;}

    input.ng-valid{border:5px solid green;}`
  ]
})
export class RegisterComponent {

  userName:any="";
  mobileNo:any="";
  emailId:any="";
  constructor(private userService:UserService){}
  submitForm(){
    var body={
      uname:this.userName,
      mobile:this.mobileNo,
      email:this.emailId
    }
    this.userService.addUserInformation(body).subscribe(data=>{
      alert("Form submitted");
    })
  }

  
}
