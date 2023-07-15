import axios, { isCancel, AxiosError, AxiosResponse } from "axios";
import { router } from "../Routes/Routes";
import { request } from "http";
import Jeu from "../../Modele/Jeu";
import Utilisateur from "../../Modele/Utilisateur";
import Equipe from "../../Modele/Equipe";
import Pari from "../../Modele/Pari";
import PariDTO from "../../Modele/PariDTO";
import { UserDTO, UserFormValues } from "../../Modele/UserDTO";
import { toast } from "react-toastify";
import CommonStore from "../Store/CommonStore";
import { store } from "../Store/store";

enum ErrorCode {
  badRequest = 400,
  notAuthorize = 401,
  forbidden = 403,
  notFound = 404,
  serverError = 503,
}
axios.defaults.baseURL = process.env.REACT_APP_API_URL;
console.log(process.env.REACT_APP_API_URL);
axios.interceptors.request.use((config) => {
  const token = store.commonStore.token;
  if (token && config) config.headers.Authorization = `Bearer ${token}`;
  return config;
});
axios.interceptors.response.use(
  (response: any) => {
    // toast.info("en cours de chargement");
    return response;
  },
  (error: AxiosError) => {
    // le toast est declare dans appendFile.tsx et css dans indexedDB.tsx
    //TODO: supprimer avant mise en prod
    // toast.error(error.message);

    const { data, status, config } = error.response as AxiosResponse;
    switch (status) {
      case ErrorCode.badRequest:
        if (config.method === "get" && data.errors.hasOwnProperty("id")) {
          router.navigate("/not-found");
        }
        if (data.errors) {
          const arrayErrors = [];
          for (const key in data.errors) {
            arrayErrors.push(data.errors[key]);
          }
          throw arrayErrors.flat();
        } else {
            const arrayErrors = [];
            for (const key in data) {
              arrayErrors.push(data[key]);
            }
            throw arrayErrors.flat();
          } 
        break;
      case ErrorCode.forbidden:
        toast.warning("Acces a cette ressource non authorisee");
        break;
      case ErrorCode.notAuthorize:
        toast.warning("Acces restreint a cette ressource");
        break;
      case ErrorCode.serverError:
        toast.error("Erreur cote serveur");
        break;
      default:
        break;
    }
    return Promise.reject(error);
  }
);

const responseBody = <T>(response: AxiosResponse<T>) => response.data;

const requests = {
  get: <T>(url: string) => axios.get<T>(url).then(responseBody),
  post: <T>(url: string, data: {}) =>
    axios.post<T>(url, data).then(responseBody),
  put: <T>(url: string, data: {}) => axios.put<T>(url, data).then(responseBody),
  del: <T>(url: string) => axios.delete<T>(url).then(responseBody),
};

const users = {
  list: () => requests.get<Utilisateur[]>("/users/"),
  details: (id: string) => requests.get<Utilisateur>(`/users/details/${id}`),
  login: (user: UserFormValues) => requests.post<UserDTO>("/login", user),
  register: (user: UserFormValues) => requests.post<UserDTO>("/register", user),
  put: (user: Utilisateur) =>
    requests.put<UserDTO>(`/update/${user.username}`, user),
  currentUser: () => requests.get<UserDTO>(`/currentuser/`),
};

const joueurs = {};

const jeux = {
  detail: (id: number) => requests.get<Jeu>(`/jeux/${id}`),
  today: () => requests.get<Jeu[]>("/jeux/dujour"),
  list: () => requests.get<Jeu[]>("/jeux/"),
  post: (jeu: Jeu) => requests.post<Jeu>("/jeux/", jeu),
  put: (jeu: Jeu) => requests.put<Jeu>(`/jeux/${jeu.id}`, jeu),
  del: (id: string) => requests.del<void>(`/jeu/${id}`),
};

const equipes = {
  details: (id: number) => requests.get<Equipe>(`equipes/${id}`),
  list: () => requests.get<Equipe[]>("/equipes/"),
  post: (equipe: Equipe) => requests.post<Equipe>("/equipes/", equipe),
  put: (equipe: Equipe) =>
    requests.put<Equipe>(`/equipes/${equipe.id}`, equipe),
  del: (id: string) => requests.del<void>(`/equipes/${id}`),
};

const paris = {
  details: (matchId: number, email: string) =>
    requests.get<Pari>(`/paris/${email}/bymatch/${matchId}/`),
  list: (userId: string) => requests.get<Pari[]>(`/paris/paruser/${userId}`),
  getId: () => requests.get<number>(`/paris/`),
  post: (pari: PariDTO) => requests.post<void>("/paris/", pari),
  put: (pari: Pari) => requests.put<void>(`/paris/${pari?.id}`, pari),
  del: (id: string) => requests.del<void>(`/paris/${id}`),
};

const agent = {
  joueurs,
  equipes,
  jeux,
  paris,
  users,
};

export default agent;
