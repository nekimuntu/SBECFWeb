import {  RouteObject, createBrowserRouter } from "react-router-dom"
import Entree from "../../Application/Entree"
import NotFound from "../Error/NotFound";
import DetailJeu from "../../Composants/Jeu/DetailJeu";
import ListJeux from "../../Composants/Jeu/ListJeux";
import LoginForm from "../../Composants/Form/LoginForm";


export const routes:RouteObject[]=[
    {
        path:"/",
        element:<Entree/>,
        children: [
            {path:"/MatchDetails/:id",element:<DetailJeu/>},
            {path:"/TousLesMatch",element:<ListJeux jeuDuJour={false} />},
            {path:"/Login",element:<LoginForm />},
            {path:"not-found/",element:<NotFound/>},
        ],        
    }
];

export const router = createBrowserRouter(routes);