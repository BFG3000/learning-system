import { Department } from "./Department";
import { InternalUserRole } from "./InternalUserRole";
import { User } from "./User";

export interface InternalUser{
    id : number;
    username:string;
    passwordHash? : string;
    departmentId? : number;
    department? : Department;
    userId : number;
    user: User;
    internalUserRoles? : InternalUserRole[] | null;
}