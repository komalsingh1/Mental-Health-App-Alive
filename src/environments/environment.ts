// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
  dialogflow :{
    oliver: '4a03c7f77aaa423da8ca8397ab9906fd'
  },
  baseUrl:"https://localhost:44340",
  userRegistrationApi : {
    route:"/api/User",
    signUpEndpoint:"/SignUp",
    loginEndpoint:"/Login"
  },
  mentalHealthTestApi:{
    route:"/api/mentalHealthTest",
    getQuestionEndpoint:"/question",
    saveAnswerEndpoint:"/answer/",
    getResultEndpoint:"/result/"
  }
};



/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
