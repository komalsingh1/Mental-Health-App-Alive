import { Component, OnInit } from '@angular/core';
import {GlobalService} from '../../Services/global.service'

@Component({
  selector: 'app-selfassessment',
  templateUrl: './selfassessment.component.html',
  styleUrls: ['./selfassessment.component.css']
})
export class SelfassessmentComponent implements OnInit {

  constructor(private globalService : GlobalService) { }

  ngOnInit(): void {
    this.isMusicOn=this.globalService.isMusicOn
  }
public testType: string;
  public displayMain: boolean= true;
  public displayAnxiety: boolean= false;
  public displayDepression: boolean= false;
  public displayStress: boolean= false;
  
  public isMusicOn :boolean 
  public anxietyTestTitle : string ="Are you feeling anxious? Take an anxiety test now"
  public depressionTestTitle : string ="Are you feeling depressed? Take an depression test now"
  public stressTestTitle : string ="Are you feeling stressed? Take an stress test now"
  AnxietyTransition(): void {
    this.displayAnxiety=true;
    this.displayMain=false;
    this.testType="Anxiety"
  }
  toggleMusic():void{
    this.globalService.toggleMusic();
    this.isMusicOn=this.globalService.isMusicOn
  }
  DepressionTransition(): void {
    this.displayDepression=true;
    this.displayMain=false;
    this.testType="Depression"
  }
  StressTransition(): void {
    this.displayStress=true;
    this.displayMain=false;
    this.testType="Stress"
  }
  CloseAssesmmentHandler($event: any){
    this.displayAnxiety=false;
    this.displayStress=false;
    this.displayDepression=false;
    this.displayMain=true;
  }
}
