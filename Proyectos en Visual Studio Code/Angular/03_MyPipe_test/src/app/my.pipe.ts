import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'myPipe'
})
export class MyPipe implements PipeTransform {

  transform(value: any, ...args: any[]): any {
    return value + "blablablabla" +args;
  }

}
