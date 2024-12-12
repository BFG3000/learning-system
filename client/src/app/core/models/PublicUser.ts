import { Department } from "./Department";
import { InternalUserRole } from "./InternalUserRole";
import { User } from "./User";

export interface PublicUser{
    id : number;
    userId : number;
    user: User;
    RegistrationDate? : Date;
}