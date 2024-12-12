import { Answer } from "./Answer";
import { Result } from "./Result";

export interface AnswerResult {
    id: number;
    answerId: number;
    resultId: number;
    answer: Answer | null;
    result: Result | null;
  }
  