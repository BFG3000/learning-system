import { Exam } from "./Exam";
import { User } from "./User";

export interface UserExam {
    id: number;
    userId: number;
    examId: number;
    user?: User | null;
    exam?: Exam | null;
  }
  