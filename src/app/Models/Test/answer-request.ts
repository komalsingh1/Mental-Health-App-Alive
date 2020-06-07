export class AnswerRequest {
    constructor(public userId: string,public testType: string,public questionNumber: number,public optionNumber: number ) {}
}
