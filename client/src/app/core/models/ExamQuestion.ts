import { ExamVariant } from "./ExamVariant";
import { Question } from "./Question";

export interface ExamQuestion {
    id: number;
    examVariantId: number;
    questionId: number;
    examVariant?: ExamVariant | null;
    question?: Question | null;
  }
  