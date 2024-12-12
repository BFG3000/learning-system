import { InternalUserRole } from "./InternalUserRole";

export interface Role {
    id: number;
    name?: string | null;
    internalUserRoles?: InternalUserRole[] | null;
  }
  