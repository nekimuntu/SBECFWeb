import { observer } from "mobx-react"
import { Link } from "react-router-dom"
import { Button, Header, Icon, Item, Label, Segment } from "semantic-ui-react"
import Jeu from "../../Modele/Jeu"
import { useEffect } from "react"
import { useStore } from "../../Fonctions/Store/store"

interface Props {
    jeu: Jeu
}
export default observer(function DetailJeuHeader() {
    const { jeuStore, equipeStore } = useStore();

    if (jeuStore.matchSelected == undefined)
        jeuStore.getMatchSelected();
    useEffect(() => {
        const matchSelected = jeuStore.getMatchSelected();

    }, [jeuStore, jeuStore.getMatchSelected])

    const jeu = jeuStore.matchSelected!;
    console.log("Date : jeu = " + JSON.stringify(jeu))
    return (
        <Segment.Group>
            <Segment basic attached='top' style={{ padding: '0' }}>

                <Segment basic>
                    <Item.Group >
                        <Header
                            textAlign="center"
                            className="dateRencontre"
                            size='medium'
                            style={{ color: 'black' }}
                            icon={"time"}
                        > {`${String(jeu.dateRencontre).slice(0,10)} 
                        a partir de ${String(jeu.heureDebut).slice(0,5)}
                        // heure de fin prevu ${jeu.heureFin }`}</Header>
                        <Item>
                            <Item.Content>
                                {/* <p>{format(activity.date!,'dd MM yyyy h:mm aa')}</p> */}
                                <p>
                                    <Icon name="cloud" /> meteo Prevue : <strong>{jeu.meteo}</strong>
                                </p>
                            </Item.Content>
                            <Item.Content>
                                <Label pointing='right'>Match {jeu.status}</Label>
                            </Item.Content>
                        </Item>
                    </Item.Group>
                </Segment>
            </Segment>
            {/* <Segment clearing attached='bottom'>
            <Button as={Link}  color='orange' floated='right'>
                Miser
            </Button>
        </Segment> */}
        </Segment.Group>
    )
})