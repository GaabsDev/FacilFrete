import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-card-home',
  templateUrl: './card-home.component.html',
  styleUrls: ['./card-home.component.css']
})
export class CardHomeComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  @Input()
  public elemento: any;

  @Output('clickCheckbox')
  public onChange: EventEmitter<any> = new EventEmitter();

  public clickSelect(event, obj): void {
      this.onChange.emit({event, obj});
  }

}
