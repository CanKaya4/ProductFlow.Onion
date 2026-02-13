export interface User {
  id?: number | string;
  firstName: string;
  lastName: string;
  username: string;
  email: string;
  password?: string; 
  token?: string;   
}