import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'size'
})
export class SizePipe implements PipeTransform {

  transform(value: number, optional?: any): string {
    if(value>=10 && value<=19)
    {
      return "Small";
    }
    else if(value>=20 && value<=29)
    {
      return "Medium";
    }
    else if(value>=30 && value<=39)
    {
      return "Large";
    }else if(value>=40 && value<=49)
    {
      return "XL";
    }else if(value>=50 && value<=59)
    {
      return "XXL";
    }else if(value>=60 && value<=120)
    {
      return "XL+";
    }
    else 
    {
      return "Please enter the proper number";
    }
  }

}
