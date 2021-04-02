import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Customer } from '../common/customer';
 
@Component({
  selector: 'app-customercard',
  templateUrl: './customercard.component.html',
  styleUrls: ['./customercard.component.css']
})
export class CustomercardComponent implements OnInit {
  @Input()
  customers:Customer[] = [];
  


  @Output()
  delEvent:EventEmitter<number> = new EventEmitter<number>();

  constructor() { }

  ngOnInit(): void {
  }

  deleteCard(id:number) : void {
    console.log("card delete", id);
    this.delEvent.emit(id);
  }
}
