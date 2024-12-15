import { Category } from "./Category";
import { Exam } from "./Exam";
import { ExamType } from "./ExamType";
import { ExamVariant } from "./ExamVariant";

export interface ExamDefinition {
    id: number;
    examDefinitionName?: string | null;
    categoryId?: number;
    duration: number;
    examTypeId?: number;
    examType?: ExamType | null;
    examVariants?: ExamVariant[] | null;
    exams?: Exam[] | null;
    category?: Category | null;
  }
  