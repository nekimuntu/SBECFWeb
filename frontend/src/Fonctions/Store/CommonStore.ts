import { makeAutoObservable, reaction } from 'mobx';

import agent from "../Api/agent"

//Class utilisee pour stocker le token user / 
export default class CommonStore{
    
   //properties 
//    error: ServerError | null = null;
      token: string | null = localStorage.getItem("jwt");
      
      appLoaded = false;

   //mobx constructor
   constructor(){
        makeAutoObservable(this);

        //reaction va agir des qu'il y a une modification du token
        reaction(
            ()=> this.token,
            token => {
               if(token) localStorage.setItem("jwt",token);
               else localStorage.removeItem("jwt");
            }
        )
   }
   
   //getteur et setteur des properties 
   setToken = (token:string|null) => {
      this.token = token;
   }

   setAppLoaded = () =>{
      this.appLoaded = !this.appLoaded;
   }
}