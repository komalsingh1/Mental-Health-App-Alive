import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GlobalService {

  constructor() { }
  isMusicOn:boolean = true
  userId : string = "DIPIKA"
  testId : string
  testType : string
  getUserId():string{
    return this.userId;
  }
  setUserId(id : string){
    this.userId=id
  }
toggleMusic(){
  this.isMusicOn=!this.isMusicOn
}
  getTestId():string{
    return this.testId;
  }
  setTestId(id : string){
    this.testId=id
  }

  getTestType():string{
    return this.testType;
  }
  setTestType(id : string){
    this.testType=id
  }
}
