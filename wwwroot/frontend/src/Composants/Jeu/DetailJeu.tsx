import { observer } from "mobx-react";

import { Container, Grid, ModalContent } from 'semantic-ui-react'
import { useStore } from "../../Fonctions/Store/store";
import SideBarMiseForm from "../Form/SideBarMiseForm";

import DetailJeuInfo from "./DetailJeuInfo";
import DetailJeuHeader from "./DetailJeuHeader";
import { useEffect } from "react";

import { StatutMatch } from "../../Modele/Constantes/StatutMatch";
import SideBarLoginForm from "../Form/SideBarLoginForm";

export default observer(function DetailJeu() {
    const { jeuStore, equipeStore, pariStore, usersStore } = useStore();
    
    
    // console.log("le match est "+ JSON.stringify(matchSelected))
    useEffect(()=>{
        const matchSelected = jeuStore.getMatchSelected();
        equipeStore.loadDetailsEquipes([matchSelected?.equipeAId!, matchSelected?.equipeBId!]);
    },[jeuStore,equipeStore])
    const matchSelected = jeuStore.matchSelected;
    console.log("Detai Jeu, Match = " + matchSelected)
    

    
    const equipes = equipeStore.equipeArray;

    if (matchSelected?.statusCode === StatutMatch.Avenir && usersStore.isLoggedIn) {
        return (
            <Grid >
                <Container>
                    <DetailJeuHeader  />
                </Container>
                <ModalContent />
                <Grid.Column width={12}>
                    <Container style={{ marginTop: '2em' }}>
                        <DetailJeuInfo equipes={equipes} />
                    </Container>
                </Grid.Column>

                <Grid.Column width={4} >
                    <Container style={{ marginTop: '7em' }}>
                        <SideBarMiseForm jeu={matchSelected} equipes={equipes} pariId={pariStore.idParis} />
                    </Container>
                </Grid.Column>

            </Grid >
        )
    }
    if (matchSelected?.statusCode! <= StatutMatch.Termine && usersStore.isLoggedIn) {
        return (
            <Grid >
                <Container>
                    <DetailJeuHeader  />
                </Container>

                <Grid.Column width={12}>
                    <Container style={{ marginTop: '2em' }}>
                        <DetailJeuInfo equipes={equipes} />
                    </Container>
                </Grid.Column>

                <Grid.Column width={4} >
                    <Container style={{ marginTop: '7em' }}></Container>
                </Grid.Column>
            </Grid>
        )
    }
    else {
        return (
            <Grid >
                <Container>
                    <DetailJeuHeader  />
                </Container>

                <Grid.Column width={12}>
                    <Container style={{ marginTop: '2em' }}>
                        <DetailJeuInfo equipes={equipes} />
                    </Container>
                </Grid.Column>

                <Grid.Column width={4} >
                    <Container style={{ marginTop: '7em' }}>
                        <SideBarLoginForm />
                    </Container>
                </Grid.Column>

            </Grid >
        )
    }

})