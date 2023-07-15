import Equipe from "./Equipe";
import Jeu from "./Jeu";
import Utilisateur from './Utilisateur';

export default interface Pari{
    id:number|null,
    matchId:number,
    jeu:Jeu|undefined,
    userId:string,
    utilisateur:Utilisateur|undefined,
    montantMise:number,
    montantGagne:number,
    dateMise:Date,
    equipeId:number,
    equipe:Equipe|undefined
}