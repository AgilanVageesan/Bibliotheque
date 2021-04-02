import { Directive, ElementRef, Renderer2, HostListener, HostBinding } from '@angular/core';
//<div appHover>
 // <img />
//</div>
@Directive({
  selector: '[appHover]'
})
export class AppHoverDirective {

  @HostBinding('style.border') border: string = '';

  // Dependency Injection
  constructor(private el:ElementRef, private  renderer: Renderer2) { }

  @HostListener("mouseover")
  onMouseOver() {
    let part = this.el.nativeElement.querySelector('.image');
    this.renderer.setStyle(part, 'display', 'block');
    this.border = '3px solid red';
  }

  @HostListener("mouseout")
  onMouseOut() {
    let part = this.el.nativeElement.querySelector('.image');
    this.renderer.setStyle(part, 'display', 'none');
    this.border = '';
  }
}
