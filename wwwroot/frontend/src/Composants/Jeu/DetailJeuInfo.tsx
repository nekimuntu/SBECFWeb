import { Grid, GridRow, Item, Image, Label, List, SemanticWIDTHS } from "semantic-ui-react";
import Equipe from "../../Modele/Equipe";

interface Props {
    equipes: Equipe[]
}
export default function DetailJeuInfo({ equipes }: Props) {

    return (
        <Grid inverted>
            <GridRow centered ><h1>Rencontre</h1></GridRow>
            {equipes.map(equipe => (
                <Grid.Column width={8}>
                    <Item.Group divided key={equipe.id}>
                        <Item key={equipe.id}>
                            <Image size="tiny" circular src={`${equipe.urLlogo}`} />
                            <Item.Content>
                                <Item.Header as='a'>{equipe.nom}</Item.Header>
                                <Item.Meta>
                                    <span className='pays'>{(equipe.pays).name}</span>
                                </Item.Meta>
                                <Item.Description>
                                    <List>
                                        {equipe.joueurs.map(joueur => (
                                            <List.Item key={joueur.id}>
                                                <List.Icon key={`user${joueur.id}`} name='users' />
                                                <List.Content>{`${joueur.nom} ${joueur.prenom}`}
                                                </List.Content>
                                               <List.Icon name='world'  />
                                                <List.Content>{`${joueur.pays.name}`}</List.Content>
                                                
                                            </List.Item>
                                        ))}
                                    </List>
                                </Item.Description>

                                <Item.Extra>
                                    <Label icon='dollar' >
                                        {`Cote: ${equipe.cote.toString()}`}
                                    </Label>
                                </Item.Extra>
                            </Item.Content>
                        </Item>
                    </Item.Group>
                </Grid.Column>
            ))}
        </Grid>
    );
}