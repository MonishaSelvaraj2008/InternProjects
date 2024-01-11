import { Injectable } from '@angular/core';
import { of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
isLoggedIn:boolean=false;
userName:any="";
password:any="";

constructor() { }
login(username:any,password:any){
  this.userName=username;
  this.password=password;
  this.isLoggedIn=true;
  return of(this.isLoggedIn);
}

isUserLoggedIn():boolean{
  return this.isLoggedIn;
}

isAdminUser():boolean{
  console.log("un"+this.userName)
  if(this.userName=="admin"){
    return true;
  }
  return false;
}
logoutUser(){
  this.isLoggedIn=false;
}
}
