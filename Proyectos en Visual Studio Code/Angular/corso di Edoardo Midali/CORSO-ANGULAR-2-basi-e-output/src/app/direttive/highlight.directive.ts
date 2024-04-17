import { Directive, ElementRef, HostListener, Input } from '@angular/core';

@Directive({
  selector: '[appHighlight]',
  standalone: true
})
export class HighlightDirective {

  @Input() appHighlight =''
;  constructor(private element: ElementRef<HTMLParagraphElement>) { 
  }
  
  @HostListener('mouseenter') onMouseEnter(){
    this.cambiaColore('green');
  }
  @HostListener('mouseleave') onMouseLeave(){
    this.cambiaColore('yellow');
  }
  
  cambiaColore(colore:string){
    this.element.nativeElement.style.backgroundColor=colore;
  }
}
