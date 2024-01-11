import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-binding',
  templateUrl: './binding.component.html',
  styleUrls: ['./binding.component.css']
})
export class BindingComponent {
  searchData:any="yet to search";

@Input() pmessage:any=""

@Output() cmessage=new EventEmitter();
  constructor() { }
  ngOnInit()
  {

  }
sendMessage(){
  this.cmessage.emit("Ok parent");
}
}
