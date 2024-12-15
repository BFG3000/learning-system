import { ExamDefinition } from "./ExamDefinition";
import { ExamQuestion } from "./ExamQuestion";
import { Result } from "./Result";

export interface ExamVariant {
    id?: number;
    examDefinitionId?: number;
    variantName?: string | null;
    examQuestions?: ExamQuestion[] | null;
    results?: Result[] | null;
    examDefinition?: ExamDefinition | null;
  }
  