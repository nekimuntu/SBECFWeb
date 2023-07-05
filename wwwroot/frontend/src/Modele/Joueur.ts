import Equipe from "./Equipe";
import Pays from "./Pays";

export default interface Joueur{
    id:number,
    nom:string,
    prenom:string,
    numero:number,
    equipeId:number,
    equipe:Equipe,
    paysId:number,
    pays:Pays
}