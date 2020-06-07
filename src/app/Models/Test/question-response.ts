import { Option } from './option';

export class QuestionResponse {
    constructor(public question: string, public options: Option[]) {}
}
