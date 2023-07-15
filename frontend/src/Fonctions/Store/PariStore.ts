import { makeAutoObservable, set } from "mobx";
import Pari from "../../Modele/Pari";
import agent from "../Api/agent";
import { toast } from "react-toastify";
import PariDTO from "../../Modele/PariDTO";

export default class PariStore {
  
  //properties
  loading = false;
  submitting = false;
  firstPari = true;
  listParis = new Array<Pari>();
  lePariDto: PariDTO | undefined = undefined;
  lePari:Pari|undefined = undefined;
  idParis:number = 0;

  //constructor
  constructor() {
    makeAutoObservable(this);
  }

  //Getteur
  
  
  //fonction pour l US .. afficher un diagramme des paris
  getListPariByUser = async (userId: string) => {
    //peut etre qu il faudra une methode pour metre a jour loading
    this.setLoading(true);
    try {
      //check in database what we got
      let lParis = await agent.paris.list(userId);
      if (lParis!==null){
        lParis.forEach(pari => {this.listParis.push(pari)});
      }
    } catch (error) {
        console.log(error);
      //toast.error("probleme lors du chargement des mises");
      
    }finally{this.setLoading(false)}
  };

  //fonction pour retrouver le pari sur un match du user
  getPariByMatch = async (matchId: number,email:string) => {
    this.setLoading(true);
    try {
      //check in database what we got
      let aParis = await agent.paris.details(matchId,email);
      if(aParis!==null){
        this.setPari(aParis);
        this.setFirstPari(false);
      }
      
    } catch (error) {
        toast.info("aucune mise pour le moment...")
    }
    finally{
        this.setLoading(false)
    }
  };

  savePari = async (pari?: Pari,pariDto?:PariDTO) => {
    this.setSubmit(true);
    try {       
        if(this.firstPari||pari==undefined){
            this.setPariDto(pariDto!);
            let lepari = await agent.paris.post(pariDto!)            
            this.setSubmit(false);
        }
        else{
          this.setPari(pari!)
            let lepari = await agent.paris.put(pari!)
            this.setSubmit(false);
        }
    } catch (error) {
        // toast.error("Impossible d enregistrer la mise")
        this.setSubmit(false)
    }
  };

//setteur 
  setPari(pari:Pari){
    this.lePari = pari;
  }
  setPariDto(pari:PariDTO){
    this.lePariDto = pari;
  }
  setPariId(pariId:number){
    this.idParis = pariId;
  }
  setFirstPari(state:boolean){
    this.firstPari=state;
  }
  setSubmit(state:boolean){
    this.submitting = state;
  }
  setLoading(state: boolean) {
    this.loading = state;
}
}
