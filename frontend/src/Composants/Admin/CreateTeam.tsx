import React, { useState, useRef, useEffect } from "react";

import { useParams, useNavigate } from "react-router";

import axios from "axios";
import agent from "../../Fonctions/Api/agent";
import Pari from "../../Modele/Pari";
import PariDTO from "../../Modele/PariDTO";



export function EditProfileForm()
{
  const { id } = useParams();
  // const navigate = useNavigate();

  const [currentPari, setCurrentPari] = useState<Pari>();

  const [updatedPari, setUpdatedPari] = useState<Pari>({
    id:0,matchId:0, userId:"",montantGagne:0, dateMise:new Date, equipeId:0,jeu:undefined,utilisateur:undefined,equipe:undefined,
    montantMise:0
  });

  const montantMiseInputRef = useRef<HTMLInputElement>(null);
  // const lastNameInputRef = useRef<HTMLInputElement>(null);
  // const emailInputRef = useRef<HTMLInputElement>(null);

  const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => 
  {
    const { target } = event;

    if (montantMiseInputRef.current) 
    {
      setUpdatedPari((prevState) => ({
          ...prevState,
          userId:montantMiseInputRef.current!.value
          // montantMise:Number.parseInt(montantMiseInputRef.current!.value),
        }));
    }
    // if (lastNameInputRef.current) {
    //   setUpdatedProfile((prevState) => ({
    //     ...prevState,
    //     lastName: lastNameInputRef.current!.value,
    //   }));
    // }
    // if (emailInputRef.current) {
    //   setUpdatedProfile((prevState) => ({
    //     ...prevState,
    //     email: emailInputRef.current!.value,
    //   }));
  }


  const handleSubmitAndRedirect = () => {
    const data =  updatedPari ;

    try {
      agent.paris.put(updatedPari)
    } catch (error: any) {
      console.error(error.response.data);
    }

   console.log(updatedPari)
  };

  useEffect(() => {
    (async () => {
      try {
        const data  = await agent.paris.details(3,"nago@test.com")
        setCurrentPari(data);
        console.log("pari dans useEffect = "+JSON.stringify(currentPari));
      } catch (error: any) {
        console.error(error.response.data);
      }
    })();
  }, [setCurrentPari]);
  

  useEffect(() => {
    if (montantMiseInputRef.current) {
      montantMiseInputRef.current.value = currentPari?.userId || "";
    }   
    console.log(JSON.stringify("secon useefct = "+currentPari)) 
  }, [
    currentPari?.montantGagne
  ]);
  console.log("montant "+ updatedPari?.userId);
  return (
    <form onSubmit={handleSubmitAndRedirect}>
      <label>username {updatedPari?.userId}</label><br></br>
      <input ref={montantMiseInputRef} name="montantmise" onChange={handleChange} />
      <button>Submit</button>
    </form>
  );
};