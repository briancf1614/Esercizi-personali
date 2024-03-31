import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'myTranslator'
})
export class MyTranslatorPipe implements PipeTransform {
    transform(nome: string): string {
        let name: string;
        switch (nome) {
            case 'Aldo': name = 'Al';
                break;
            case 'Giovanni': name = 'John';
                break;
            case 'Giacomo': name = 'Jack';
                break;
            default: name = '';
        }
        return name;
    }
}
