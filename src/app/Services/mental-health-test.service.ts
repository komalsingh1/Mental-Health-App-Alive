import { Injectable } from '@angular/core';
import {QuestionRequest} from '../Models/Test/question-request'
import {QuestionResponse} from '../Models/Test/question-response'
import {AnswerRequest} from '../Models/Test/answer-request'
import {AnswerResponse} from '../Models/Test/answer-response'
import {ResultRequest} from '../Models/Test/result-request'
import {ResultResponse} from '../Models/Test/result-response'
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { environment } from '../../environments/environment';
import {Error} from '../Models/Common/error'
import { catchError, retry } from 'rxjs/operators';
import { Observable, of, throwError, BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MentalHealthTestService {
  _error: Error;
  public headers = new HttpHeaders({
    "Content-Type": "application/json"
  });
  constructor(
    private http: HttpClient
  ) { }
  GetQuestion(questionRequest:QuestionRequest):Observable<QuestionResponse>{
    return this.http.post<QuestionResponse>(this.getUrl(environment.mentalHealthTestApi.getQuestionEndpoint), questionRequest, {
      headers: this.headers
    }).pipe(
      retry(1),
      catchError(this.errorHandler)
    );
  }
  GetResult(resultRequest:ResultRequest,testId:string):Observable<ResultResponse>{
    return this.http.post<ResultResponse>(this.getUrl(environment.mentalHealthTestApi.getResultEndpoint+testId), resultRequest, {
      headers: this.headers
    }).pipe(
      retry(1),
      catchError(this.errorHandler)
    );
  }
  SaveAnswer(answerRequest:AnswerRequest , testId:string):Observable<AnswerResponse>{
    return this.http.post<AnswerResponse>(this.getUrl(environment.mentalHealthTestApi.saveAnswerEndpoint+testId), answerRequest, {
      headers: this.headers
    }).pipe(
      retry(1),
      catchError(this.errorHandler)
    );
  }
  private getUrl(endpoint: string): string {
    return environment.baseUrl +
      environment.mentalHealthTestApi.route +
      endpoint;
  }
  errorHandler(error: HttpErrorResponse) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      errorMessage = `Error: ${error.error.message}`;
    } else {
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    return throwError(errorMessage);
  }
}
