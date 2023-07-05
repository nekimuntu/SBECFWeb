import React, { useEffect } from 'react'
import { Icon, Label, Menu, Table } from 'semantic-ui-react'
import { useStore } from '../../Fonctions/Store/store'
import { observer } from 'mobx-react-lite';
import { Link, useLocation, useParams } from 'react-router-dom';
import LoadingComponent from '../LoadingComponent';


interface Props{
    jeuDuJour:boolean
}

export default observer(function ListeJeux({jeuDuJour}:Props) {
    const { jeuStore } = useStore();
    useEffect(() => {
        jeuStore.afficheMatchDuJour = jeuDuJour
        jeuStore.loadJeux();
    }, [jeuStore]);
    const { jeuxByDate } = jeuStore;
    const location  = useParams();
    function selectJeu(id: number): void {
        jeuStore.setJeuById(id);
    }
    if (jeuStore.loading)
        return (<LoadingComponent inverted content='Liste des match en cours de chargement' />);
    return (
        
        <Table celled>
            <Table.Header>
                <Table.Row>
                    <Table.HeaderCell>Equipes</Table.HeaderCell>
                    <Table.HeaderCell>Date - Heure</Table.HeaderCell>
                    <Table.HeaderCell>Score</Table.HeaderCell>
                    <Table.HeaderCell>Status</Table.HeaderCell>
                </Table.Row>
            </Table.Header>
            <React.StrictMode>
                <Table.Body>
                    {jeuxByDate.map(jeu => {                        
                            return (<Table.Row key={jeu.id} >
                                <Table.Cell>
                                    <Link onClick={() => selectJeu(jeu.id)} to={`/MatchDetails/${jeu.id}`}> 
                                        <Label ribbon>{jeu.equipeA.nom} vs {jeu.equipeB.nom}</Label>
                                    </Link>
                                </Table.Cell>
                                <Table.Cell> {jeu.dateRencontre.toLocaleDateString()} - {jeu.heureDebut.toString()} </Table.Cell>
                                <Table.Cell> {jeu.scoreEquipeA} - {jeu.scoreEquipeB} </Table.Cell>
                                <Table.Cell>{jeu.status}</Table.Cell>
                            </Table.Row>)
                    }
                    )}
                </Table.Body>
            </React.StrictMode>
            {/* Footer */}
            <Table.Footer>
                <Table.Row>
                    <Table.HeaderCell colSpan='3'>
                        <Menu floated='right' pagination>
                            <Menu.Item as='a' icon>
                                <Icon name='chevron left' />
                            </Menu.Item>
                            <Menu.Item as='a'>1</Menu.Item>
                            <Menu.Item as='a'>2</Menu.Item>
                            <Menu.Item as='a'>3</Menu.Item>
                            <Menu.Item as='a'>4</Menu.Item>
                            <Menu.Item as='a' icon>
                                <Icon name='chevron right' />
                            </Menu.Item>
                        </Menu>
                    </Table.HeaderCell>
                </Table.Row>
            </Table.Footer>
        </Table>
    );
});