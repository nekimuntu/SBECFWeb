
import React from 'react'

import { observer } from 'mobx-react-lite'
import { Outlet, useLocation } from 'react-router-dom'
import { Container, Grid } from 'semantic-ui-react'
import { ToastContainer } from 'react-toastify'
import SBHeader from '../Composants/Header'
import SBMenu from '../Composants/Menu'
import ListeJeux from '../Composants/Jeu/ListJeux'

const Entree = () => {
    const location = useLocation();
    return (
        <>
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
