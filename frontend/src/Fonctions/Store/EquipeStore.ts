import { makeAutoObservable } from 'mobx';
import agent from "../Api/agent"
import Equipe from '../../Modele/Equipe';

export default class EquipeStore{
    
   //properties 
   listEquipe = new Map<number,Equipe>();
   equipe:Equipe | undefined = undefined;
   editMode = false;
   submitting = false;
   loading=false;

   //mobx constructor
   constructor(){
        makeAutoObservable(this);
   }
   //On va chercher la liste des joueurs par Equipes et on le garde dans le store 
   // listEquipe est en charge de garder les matchs
   
   loadDetailsEquipes = async (ids:number[]) => {   
     this.listEquipe.clear(); 
        try {
            let equipe1 = await agent.equipes.details(ids[0]);
            this.setEquipe(equipe1);
            let equipe2 = await agent.equipes.details(ids[1]);
            this.setEquipe(equipe2);
            this.setLoading(false);
        } catch (error) {
            console.log(error);
            this.setLoading(false);
        }
   }

   get equipeArray(){
        return Array.from(this.listEquipe.values());
   }
   setLoading = (state: boolean) => {
       this.loading = state; 
   }
   setEquipe = (equipe:Equipe) =>{
        
        this.listEquipe.set(equipe.id,equipe);
        
   }
   
}