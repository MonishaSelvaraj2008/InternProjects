import { Directive, ElementRef, HostListener } from '@angular/core';

@Directive({
  selector: '[appApphighlighter]'
})
export class ApphighlighterDirective {
  constructor(private  elementRef: ElementRef) { }

  @HostListener('MouseEnter')
  mouseEnter()
  {
    this.highlighter("Yellow");
  }

  @HostListener('MouseLeave')
  mouseLeave()
  {
    this.highlighter("")
  }

  highlighter(color:any)
  {
    //this.elementRef.nativeELement.style.backgroundColor=color;
  }
  

 }
