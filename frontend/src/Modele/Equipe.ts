import Joueur from "./Joueur";
import Pays from "./Pays";

export default interface Equipe{
    id:number,
    nom:string,
    cote:number,
    paysId:number,
    urLlogo:string,
    pays:Pays,
    joueurs:Joueur[]
}