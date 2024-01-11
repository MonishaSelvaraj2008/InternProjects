import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'gender'
})
export class GenderPipe implements PipeTransform {

  transform(data: any, optional?: any): string {
    if(optional=='F')
    return "Ms. "+data;
    else
    return "Mr. "+data;
  }

}
