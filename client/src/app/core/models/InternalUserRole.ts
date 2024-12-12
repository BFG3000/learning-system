import { InternalUser } from "./InternalUser";
import { Role } from "./Role";

export interface InternalUserRole{
    id : number;
    internalUserId : number ;
    internalUser : InternalUser;
    roleId : number;
    role : Role ;
    createdAt : Date;
}