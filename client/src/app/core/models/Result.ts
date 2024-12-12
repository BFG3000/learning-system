import { AnswerResult } from "./AnswerResult";
import { ExamVariant } from "./ExamVariant";
import { UserExam } from "./UserExam";

export interface Result {
    id: number;
    userExamId: number;
    examVariantId: number;
    score: number;
    startDate: string;
    endDate: string;
    userExam?: UserExam | null;
    examVariant?: ExamVariant | null;
    answerResults?: AnswerResult[] | null;
  }
  