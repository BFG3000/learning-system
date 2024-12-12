import { ExamDefinition } from "./ExamDefinition";
import { UserExam } from "./UserExam";

export interface Exam {
    id: number;
    name: string;
    startDate: string;
    endDate: string;
    locationId: number;
    examDefinitionId: number;
    examDefinition?: ExamDefinition | null;
    location?: Location | null;
    userExams?: UserExam[] | null;
  }
  