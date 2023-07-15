import Equipe from "./Equipe"

export default interface Jeu{
id:number, 

equipeAId:number,
equipeA:Equipe,

equipeBId: number, 
equipeB:Equipe,

meteo:string,

dateRencontre: Date, 

heureDebut : Date,
heureFin: Date, 


scoreEquipeA:number,

scoreEquipeB:number,

equipeGagnante:number

commentaires:string,

status: string,
statusCode:number
}