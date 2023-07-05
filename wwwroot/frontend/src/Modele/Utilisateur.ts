export default interface Utilisateur{
    id:string,
    Nom:string,
    Prenom:string,
    roleVisiteur:Boolean|null,
    roleUtilisateur:Boolean|null,
    roleCommentateur:Boolean|null,
    roleAdmin:Boolean|null
}