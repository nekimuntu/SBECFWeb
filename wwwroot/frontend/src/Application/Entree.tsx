

import React, { useEffect } from 'react'

import { observer } from 'mobx-react-lite'
import { Outlet, useLocation } from 'react-router-dom'
import { Container, Grid } from 'semantic-ui-react'
import { ToastContainer } from 'react-toastify'
import SBHeader from '../Composants/Header'
import SBMenu from '../Composants/Menu'
import ListeJeux from '../Composants/Jeu/ListJeux'
import { useStore } from '../Fonctions/Store/store'
import LoadingComponent from '../Composants/LoadingComponent'
import ModalContainer from '../Composants/Modal/ModalContainer'

const Entree = () => {
    const location = useLocation();
    const {usersStore,commonStore} = useStore();
    useEffect(()=>{
        if(commonStore.token){
            usersStore.getUser().finally(()=>commonStore.setAppLoaded());
        }else{
            commonStore.setAppLoaded();
        }
    },[commonStore,usersStore])

    // if(!commonStore.appLoaded) return <LoadingComponent inverted={false} content='Chargement de l application ...' />
    return (
        <>
            <ModalContainer />
            {/* Il faut aussi declarer le css dans index.tsx */}
            <ToastContainer key={'notify'} position='bottom-right' theme='colored' />

            <SBHeader />
            <SBMenu />
            <Grid >
                <Grid.Column width={2} ></Grid.Column>
                <Grid.Column width={12}>
                    <Container style={{ marginTop: '3em' }}>
                        {
                            location.pathname === "/"
                                ?
                                <ListeJeux jeuDuJour={true}></ListeJeux>
                                : <Outlet />
                        }
                    </Container>                    
                    <Grid.Column width={2}>

                    </Grid.Column>
                </Grid.Column>
            </Grid>

        </>
    );
}

export default observer(Entree);
