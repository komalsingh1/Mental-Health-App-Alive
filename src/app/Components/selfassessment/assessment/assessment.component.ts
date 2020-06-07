import { Component, OnInit ,Input,EventEmitter,Output } from '@angular/core';
import {GlobalService} from '../../../Services/global.service'
import {MentalHealthTestService} from '../../../Services/mental-health-test.service'
import {QuestionRequest} from "../../../Models/Test/question-request"
import {AnswerRequest} from "../../../Models/Test/answer-request"
import {ResultRequest} from "../../../Models/Test/result-request"
import { Option } from 'src/app/Models/Test/option';
@Component({
  selector: 'app-assessment',
  templateUrl: './assessment.component.html',
  styleUrls: ['./assessment.component.css']
})
export class AssessmentComponent implements OnInit {

  constructor(private globalService: GlobalService, private testService:MentalHealthTestService) { }
  @Output() close = new EventEmitter<boolean>();
  @Input() testType: string;
  @Input() displayTitle: string;
  public displaymain: boolean= true;
  public displayQuestion: boolean=false;
  public displayResult: boolean=false;
  public hasQuestion : boolean=true
  public questionNumber:number 
  public question: string ;
  public options:Option[] 
  public selectedOptionNumber : number
  public moodImageUrl:string
  public score:number
  public description : string
  public summary:string
  ngOnInit(): void {
    this.globalService.setUserId("DIPIKA")
    this.ShowMain()
  }
  OnClose(){
    this.close.emit(true);
  }
  StartTest(){
    this.globalService.setTestType(this.testType)
    this.globalService.setTestId(Guid.newGuid())
    this.questionNumber=1
    this.ShowQuestion()
    this.GetQuestion()
  }
  SubmitAndNextQuestion(){
    this.sumitAnswer()
    this.GetQuestion()
  }
  SelectedOptionHandler(optionNumber : number ){
    this.selectedOptionNumber=optionNumber
  }
  sumitAnswer(){
    var request = new AnswerRequest(this.globalService.getUserId(),this.globalService.getTestType(),this.questionNumber-1,this.selectedOptionNumber);
    this.testService.SaveAnswer(request,this.globalService.testId).subscribe(
      response=>{
      }
    )
  }
  GetQuestion(){
    var request = new QuestionRequest(this.globalService.getTestType(),this.questionNumber)
    this.testService.GetQuestion(request).subscribe(
      response=>{
        if(response.question !=null){
          this.question=response.question
          this.options=response.options
        }
        else{
          this.hasQuestion=false;
        }
      }
    );
    this.questionNumber++;
  }
  EndTest(){
    var request=new ResultRequest(this.globalService.getUserId(),this.globalService.getTestType())
    this.testService.GetResult(request,this.globalService.getTestId()).subscribe(
      response=>{
        if(response.moodImageUrl!=null){
          this.moodImageUrl=response.moodImageUrl
          this.score=response.score
          this.description=response.description
          this.summary=response.summary
        }
        else{
          this.summary="Since you have not taken any test. There is no result to display"
        }
      },
      err=>{
        this.summary="Opps you have ended the test. There is no result to display"
      }
    )
    this.ShowResult()
  }

  ShowMain(){
    this.displaymain=true
    this.displayResult=false
    this.displayQuestion=false
  }
  ShowQuestion(){
    this.displaymain=false
    this.displayResult=false
    this.displayQuestion=true
  }
  ShowResult(){
    this.displaymain=false
    this.displayResult=true
    this.displayQuestion=false
  }
}


class Guid {
  static newGuid() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function(c) {
      var r = Math.random() * 16 | 0,
        v = c == 'x' ? r : (r & 0x3 | 0x8);
      return v.toString(16);
    });
  }
}