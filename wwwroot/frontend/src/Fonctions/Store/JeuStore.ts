import { makeAutoObservable, reaction } from "mobx";
import Jeu from "../../Modele/Jeu";
import agent from "../Api/agent";

export default class JeuStore {
  //properties
  listJeux = new Map<number, Jeu>();
  matchSelected: Jeu | undefined = undefined;
  editMode = false;
  submitting = false;
  loading = false;
  //
  afficheMatchDuJour = false;

  //mobx constructor
  constructor() {
    makeAutoObservable(this);

    // reaction(
    //   ()=>this.matchSelected,
    //   match=> {
    //     if(match==undefined){
    //       console.log("state of matchselected changed")
    //       this.matchSelected = JSON.parse(localStorage.getItem("match")!);
          
    //   }else{
    //     localStorage.setItem("matchId",match.id.toString())
    //   }
    // })
  }

  getMatchSelected = () =>{
    this.matchSelected = JSON.parse(localStorage.getItem("match")!);
    return this.matchSelected;
  }
  //On va chercher la liste des Match et on le garde dans le store
  // listJeux est en charge de garder les matchs
  loadJeux = async () => {
    this.setLoading(true);
    if (this.afficheMatchDuJour) {
      try {
        const jeux = await agent.jeux.today();
        jeux.forEach((jeu) => {
          this.setJeu(jeu);
        });
        this.setLoading(false);
      } catch (error) {
        console.log(error);
        this.setLoading(false);
      }
    } else {
      try {
        const jeux = await agent.jeux.list();
        jeux.forEach((jeu) => {
          this.setJeu(jeu);
        });
        this.setLoading(false);
      } catch (error) {
        console.log(error);
        this.setLoading(false);
      }
    }
  }

  get jeuxByDate() {
    return Array.from(this.listJeux.values()).sort(
      (a, b) => a.dateRencontre!.getTime() - b.dateRencontre!.getTime()
    );
  }
  setLoading = (state: boolean) => {
    this.loading = state;
  }
  setJeu = (jeu: Jeu) => {
    jeu.dateRencontre = new Date(jeu.dateRencontre!);
    this.listJeux.set(jeu.id, jeu);
    
    // console.log("dans le setJeu "+JSON.stringify(this.matchSelected) )
  }
  setJeuById = (id: number) => {
    this.matchSelected = this.listJeux.get(id);
    localStorage.setItem("match",JSON.stringify(this.matchSelected))
  }
}
