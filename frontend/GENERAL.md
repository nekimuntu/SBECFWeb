1
Je cree l app avec typescript model : 

> npx create-react-app my-app --template typescript 

les libraries associees

npm install --save typescript @types/node @types/react @types/react-dom @types/jest 

2. Installer librairie Pour naviguer entre les differentes routes :

> npm i react-router-dom

3 Installer MobX pour gerer le stockage de donnees cotes client (navigateur)
> npm install --save mobx

4 Installer module pour acceder aux API : Axios 
> npm install axios
> npm install --save react-toastify

5 Pour la gestion des formulaires (login, register, mise ...) j installe Formik 
>npm install formik --save
>npm install yup --save

6
Pour la gestion des composants UI 
>  npm install semantic-ui-react semantic-ui-css

7
pour l enregistrement des Paris je passe par un PariDTO qui n'a pas d'Id 
en effet j ai cree la bdd avec identity autoincrement ON

8
Creation du graphique avec RECHART.JS  https://recharts.org/en-US/guide
> npm install recharts