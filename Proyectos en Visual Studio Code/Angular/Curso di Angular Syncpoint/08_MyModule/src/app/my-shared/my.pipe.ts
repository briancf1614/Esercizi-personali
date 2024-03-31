import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'myPipe'
})

export class MyPipe implements PipeTransform {
    transform(value: any, args?: any): any {
        const visibleChar = 5;
        let maskedValue = value.slice(0, -visibleChar);
        let visibleValue = value.slice(-visibleChar);
        return maskedValue.replace(/./g, '*') + visibleValue;
    }
}
