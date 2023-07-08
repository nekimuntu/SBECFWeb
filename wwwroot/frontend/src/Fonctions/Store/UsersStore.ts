import { makeAutoObservable, runInAction } from 'mobx';
import  {UserDTO, UserFormValues } from '../../Modele/UserDTO';
import agent from '../Api/agent';
import { store } from './store';
import { router, routes } from '../Routes/Routes';
// import agent from "../Api/agent"

//Class utilisee pour stocker le token user / 
export default class UsersStore{
    
   user: UserDTO|null=null;
   //properties 
//    error: ServerError | null = null;
   token: string | null = localStorage.getItem("jwt");
//    appLoaded = false;

   //mobx constructor
   constructor(){
        makeAutoObservable(this);
   }
   
   //getteur et setteur des properties 
   get isLoggedIn(){
      return !!this.user;
   }
   
   get hisRole(){
      if(this.isLoggedIn)
         return this.user?.role;
      return 0;
   }
   
   login = async (creds:UserFormValues) => {
         try {
            const user = await agent.users.login(creds);
            this.setUser(user);
            this.setToken(user.token);
            store.commonStore.setToken(user.token);
            store.modalStore.closeModal();
            router.revalidate();
            // console.log(user);
         } catch (error) {
            throw error;
         }
   }
   
   register = async (creds:UserFormValues) => {
      try {
         const user = await agent.users.register(creds);
         this.setUser(user);
         this.setToken(user.token);
         store.commonStore.setToken(user.token);
         store.modalStore.closeModal();
         router.revalidate();
         // console.log(user);
      } catch (error) {
         throw error;
      }
}

   logout = () =>{
      store.commonStore.setToken(null);
      localStorage.removeItem("jwt");
      this.user = null;
      router.navigate("/");
   }

   getUser = async () => {
      try{
         const user = await agent.users.currentUser();
         runInAction(()=>this.setUser(user))
      }catch(err){
         console.log(err);
      }
   }

   setUser = (user:UserDTO) =>{
      this.user = user;
   }
   
   setToken = (token:string|null) =>{
      if (token){
         localStorage.setItem("jwt",token);
         
      }
   }
}