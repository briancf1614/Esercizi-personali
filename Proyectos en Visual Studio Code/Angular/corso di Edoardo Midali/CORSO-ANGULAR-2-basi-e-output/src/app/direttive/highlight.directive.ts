import { Directive, ElementRef, HostListener } from '@angular/core';

@Directive({
  selector: '[appHighlight]',
  standalone: true
})
export class HighlightDirective {

  constructor(private element: ElementRef) 
  {
    this.element.nativeElement.style.backgroundColor = 'yellow'
  }

  @HostListener('mouseenter') onmouseenter(){
    this.cambiaColor('yellow')
  }
  @HostListener('mouseleave') onMouseLeave(){
    this.cambiaColor('transparent')
  }
  cambiaColor(colore: string) {
    this.element.nativeElement.style.backgroundColor = colore
  }
}
