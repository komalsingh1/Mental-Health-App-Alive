import { Component, OnInit,Input,EventEmitter,Output } from '@angular/core';
import { Option } from 'src/app/Models/Test/option';

@Component({
  selector: 'app-question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.css']
})
export class QuestionComponent implements OnInit {

  constructor() { }
@Input() question: string;
@Input() options:Option[] ;
@Output() optionEvent =new EventEmitter<number>();
public optionNumber : number
  ngOnInit(): void {
  }
  OptionCanged(){
    this.optionEvent.emit(this.optionNumber);
  }
}
