import EquipeStore from "./EquipeStore";
import JeuStore from "./JeuStore";
import { useContext,createContext } from "react";
import ModalStore from "./ModalStore";
import UsersStore from "./UsersStore";
import PariStore from "./PariStore";
import CommonStore from "./CommonStore";

interface Store{
    jeuStore:JeuStore,
    equipeStore:EquipeStore,
    modalStore:ModalStore,
    usersStore:UsersStore,
    pariStore:PariStore,
    commonStore:CommonStore
}

export const store : Store = {
    jeuStore : new JeuStore(),
    equipeStore: new EquipeStore(),
    modalStore: new ModalStore(),
    usersStore: new UsersStore(),
    pariStore:new PariStore(),
    commonStore:new CommonStore()
}

export const StoreContext = createContext(store);

export function useStore(){
    return useContext(StoreContext);
}
