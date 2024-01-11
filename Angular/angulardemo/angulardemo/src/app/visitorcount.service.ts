import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class VisitorcountService {
  visitorCount:number=0;
  constructor(){

  }
  ngOnInit(){

  }
  incrementVisitorCount()
  {
    this.visitorCount=this.visitorCount+1;
    console.log("Visitor count for today is "+this.visitorCount);
  }

 

}
