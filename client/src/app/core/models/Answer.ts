import { AnswerResult } from "./AnswerResult";
import { Question } from "./Question";

export interface Answer {
    id: number;
    question: Question | null;
    questionId: number;
    name?: string | null;
    isCorrect: boolean;
    answerResults?: AnswerResult[] | null;
  }
  