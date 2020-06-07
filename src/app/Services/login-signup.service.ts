import { Injectable } from '@angular/core';
import {SignUpRequest} from '../Models/Registration/sign-up-request'
import {SignUpResponse} from '../Models/Registration/sign-up-response'
import {LoginRequest} from '../Models/Registration/login-request'
import {LoginResponse} from '../Models/Registration/login-response'
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { environment } from '../../environments/environment';
import {Error} from '../Models/Common/error'
import { catchError, retry } from 'rxjs/operators';
import { Observable, of, throwError, BehaviorSubject } from 'rxjs';
import { ErrorInfo } from '../Models/Common/error-info';

@Injectable({
  providedIn: 'root'
})
export class LoginSignupService {
  _error: Error;
  public headers = new HttpHeaders({
    "Content-Type": "application/json"
  });
  constructor(
    private http: HttpClient
    ) { }
    Login(loginRequest:LoginRequest):Observable<LoginResponse>{
      
      return this.http.put<LoginResponse>(this.getUrl(environment.userRegistrationApi.loginEndpoint), loginRequest, {
        headers: this.headers
      }).pipe(
        retry(0),
        catchError(this.errorHandler)
      );
    }
    SignUp(signUpRequest:SignUpRequest):Observable<SignUpResponse>{
      return this.http.put<SignUpResponse>(this.getUrl(environment.userRegistrationApi.signUpEndpoint), signUpRequest, {
        headers: this.headers
      }).pipe(
        retry(0),
        catchError(this.errorHandler)
      );
    }
    private getUrl(endpoint: string): string {
      return environment.baseUrl +
        environment.userRegistrationApi.route +
        endpoint;
    }
    errorHandler(errorResponse: HttpErrorResponse) {
      var errorMessage:string
      try{
        var error = errorResponse.error as Error;
         errorMessage = `Error: ${error.Infos[0].ErrorMessage}`;
      }
      catch{
        errorMessage=`Error Code: ${errorResponse.status}\nMessage: ${errorResponse.error.title}`;
      }
      return throwError(errorMessage);
    }
}
