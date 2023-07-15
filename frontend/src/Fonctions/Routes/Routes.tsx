import {  RouteObject, createBrowserRouter } from "react-router-dom"
import Entree from "../../Application/Entree"
import NotFound from "../Error/NotFound";
import DetailJeu from "../../Composants/Jeu/DetailJeu";
import ListJeux from "../../Composants/Jeu/ListJeux";
import LoginForm from "../../Composants/Form/LoginForm";
import MySpaceDashboard from "../../Composants/Users/MySpaceDashboard";
import MatchDashboard from "../../Composants/Admin/MatchDashboard";
import { EditProfileForm } from "../../Composants/Admin/CreateTeam";


export const routes:RouteObject[]=[
    {
        path:"/",
        element:<Entree/>,
        children: [
            {path:"/MatchDetails/:id",element:<DetailJeu/>},
            {path:"/MatchDashboard/",element:<EditProfileForm/>},
            {path:"/TousLesMatch",element:<ListJeux jeuDuJour={false} />},
            {path:"/Login",element:<LoginForm />},
            {path:"/myspace",element:<MySpaceDashboard />},
            {path:"not-found/",element:<NotFound/>},
        ],        
    }
];

export const router = createBrowserRouter(routes);