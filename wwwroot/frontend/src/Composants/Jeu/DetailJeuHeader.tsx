import { observer } from "mobx-react"
import { Link } from "react-router-dom"
import { Button, Header, Icon, Item, Label, Segment } from "semantic-ui-react"
import Jeu from "../../Modele/Jeu"

interface Props{
    jeu:Jeu
}
export default observer(function DetailJeuHeader({jeu}:Props){
    return (
        <Segment.Group>
        <Segment basic attached='top' style={{padding: '0'}}>
            
            <Segment basic>
                <Item.Group >
                <Header
                                textAlign="center"
                                className="dateRencontre"
                                size='medium'
                                content={`${jeu.dateRencontre.toDateString()} 
                                    a ${jeu.heureDebut.getHours}
                                    heure de fin ${jeu.heureFin }`}
                                style={{color: 'black'}}
                                icon={"time"}
                            />
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