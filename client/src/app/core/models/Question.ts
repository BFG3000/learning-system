import { Answer } from "./Answer";
import { ExamQuestion } from "./ExamQuestion";
import { QuestionType } from "./QuestionType";

export interface Question {
    id: number;
    marks: number;
    name?: string | null;
    activityId?: number | null;
    isPublic: boolean;
    questionTypeId: number;
    questionType?: QuestionType | null;
    answers?: Answer[] | null;
    examQuestions?: ExamQuestion[] | null;
  }
  