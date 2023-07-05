import { makeAutoObservable } from "mobx";
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
  };

  get jeuxByDate() {
    return Array.from(this.listJeux.values()).sort(
      (a, b) => a.dateRencontre!.getTime() - b.dateRencontre!.getTime()
    );
  }
  setLoading = (state: boolean) => {
    this.loading = state;
  };
  setJeu = (jeu: Jeu) => {
    jeu.dateRencontre = new Date(jeu.dateRencontre!);
    this.listJeux.set(jeu.id, jeu);
    this.matchSelected = this.listJeux.get(jeu.id);
  };
  setJeuById = (id: number) => {
    this.matchSelected = this.listJeux.get(id);
  };
}
