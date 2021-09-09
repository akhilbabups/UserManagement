export interface User{
    id : string;
    fullName: string;
    roles: Role[]
}

export interface Role{
    name: string;
}