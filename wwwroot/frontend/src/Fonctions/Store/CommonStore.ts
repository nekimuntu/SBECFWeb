import { makeAutoObservable } from 'mobx';

import agent from "../Api/agent"

//Class utilisee pour stocker le token user / 
export default class CommonStore{
    
   //properties 
//    error: ServerError | null = null;
//    token: string | null = localStorage.getItem("jwt");
//    appLoaded = false;

   //mobx constructor
   constructor(){
        makeAutoObservable(this);
   }
   
   //getteur et setteur des properties 
}