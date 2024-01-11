import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-Book',
  templateUrl: './Book.component.html',
  styleUrls: ['./Book.component.css']
})
export class BookComponent implements OnInit, OnChanges {
  @Input() attrBook:any=""

  constructor() { }

  ngOnInit() {
  }

  ngOnChanges(changes: SimpleChanges): void {
      console.log("The book property got changes");
  }

}
