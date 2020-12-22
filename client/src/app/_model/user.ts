export interface User {
    id: number, 
    firstName: string,
    lastName: string,
    email: string,
    createdTime: Date,
    updatedTime: Date,
    createdById: number,
    updatedById: number,
    userType: string, 
    token : string
}