import { FormGroup } from "@angular/forms";

export function ConfirmedValidator(controlName:string , matchingControlName:string)
{
  return(formgroup: FormGroup)=>
  {
    const control=formgroup.controls[controlName];
    const matchingControl=formgroup.controls[matchingControlName];
    if(control.value!==matchingControl.value)
    {
      matchingControl.setErrors({ConfirmedValidator:true})
    }
    else{
      matchingControl.setErrors(null);
    }
  }
}
