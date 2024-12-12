import { InternalUser } from "./InternalUser";
import { PublicUser } from "./PublicUser";
import { UserExam } from "./UserExam";

export interface User {
    id: number;
    name: string;
    email: string;
    phone?: string | null;
    type: number;
    internalUser?: InternalUser | null;
    publicUser?: PublicUser | null;
    userExams?: UserExam[] | null;
  }
  