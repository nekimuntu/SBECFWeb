import { observer } from "mobx-react";

import { Container, Grid, ModalContent } from 'semantic-ui-react'
import { useStore } from "../../Fonctions/Store/store";
import SideBarMiseForm from "../Form/SideBarMiseForm";

import DetailJeuInfo from "./DetailJeuInfo";
import DetailJeuHeader from "./DetailJeuHeader";
import { useEffect } from "react";
import { useParams } from "react-router-dom";
import { StatutMatch } from "../../Modele/StatutMatch";
import SideBarLoginForm from "../Form/SideBarLoginForm";

export default observer(function DetailJeu() {
    const { jeuStore,equipeStore,pariStore } = useStore();
    
    const matchSelected = jeuStore.matchSelected;
    useEffect(() => {
        pariStore.getLastId();
        equipeStore.loadDetailsEquipes([matchSelected?.equipeAId!, matchSelected?.equipeBId!])
    }, [pariStore,equipeStore, matchSelected]);

    const location = useParams();
    // console.log(location);
    const equipes = equipeStore.equipeArray;

    if (matchSelected?.statusCode === StatutMatch.Avenir) {
        return (
            <Grid >
                <Container>
                    <DetailJeuHeader jeu={matchSelected!} />
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
    else{
        return (
            <Grid >
                <Container>
                    <DetailJeuHeader jeu={matchSelected!} />
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