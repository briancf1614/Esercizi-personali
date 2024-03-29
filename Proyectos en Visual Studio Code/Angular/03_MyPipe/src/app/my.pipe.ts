import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'myPipe'
})

export class MyPipe implements PipeTransform {
    /*
    Il metodo transform dell'interfaccia PipeTransform,
    accetta un valore ed eventuali argomenti in ingresso e restituisce il valore trasformato.
    */
    transform(value: any, ...args: any): any {
        return value + ' ####+-*-+]]] ' + args;
    }
}
