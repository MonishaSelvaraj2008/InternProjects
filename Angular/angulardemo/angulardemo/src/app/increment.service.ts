import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class IncrementService {

  count:number=0;

  incrementcounter()
  {
    this.count=this.count+1;
    console.log(this.count);
  }

  constructor() { }
}
