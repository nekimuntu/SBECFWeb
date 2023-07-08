export interface UserDTO {
  username:string;
  nom: string;
  prenom: string;
  email: string;
  token: string;
  role: number;
}

export interface UserFormValues {
  nom?: string;
  prenom?: string;
  username?:string;
  email: string;
  password: string;
  role?:number;
  error:string|null;
  
}