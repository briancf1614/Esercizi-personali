import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
    selector: 'app-child',
    templateUrl: './child.component.html',
    styleUrls: ['./child.component.css']
})

export class ChildComponent {
    title: string = 'My Child Component';

    // @INPUT
    // Decoratore @Input(): espone la proprietà all'esterno per essere utilizzata con il Property Binding
    @Input() stringaChild: string = 'Stringa Child';
  
    
    // @OUTPUT
    numeroChild = 222;
    arrayChild: number[] = [22, this.numeroChild];
    
    // Il decoratore @Output() consente di inviare dati all'esterno tramite un'istanza della classe EventEmitter.
    // Il componente espone un oggetto EventEmitter con cui emettere eventi
    // Il genitore si legherà (Event Binding) a questo evento e reagirà di conseguenza
    @Output() outputChild: EventEmitter<any> = new EventEmitter<any>();

    // Metodo per la generazione dell'evento
    childEventEmitter() {
        // La generazione dell’evento si effettua invocando il metodo emit() che accetta un unico argomento
        this.outputChild.emit(this.arrayChild);
    }
   
    // Lancia alert con eventuali argomenti
    apriAlert(arg?: string) {    
        window.alert('Click Child: ' + arg);
    }
}
