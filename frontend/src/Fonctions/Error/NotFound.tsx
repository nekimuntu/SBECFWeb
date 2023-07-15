import { Link } from "react-router-dom";
import { Button, Header, Icon, Message, Segment } from "semantic-ui-react";

export default function NotFound(){
    return(
        <Segment placeholder>
            <Header icon>
                <Icon name='search' />
                Oops - Je n ai pas trouve ce que vous cherchez ...!
            </Header>
            <Segment.Inline>
                <Button as={Link} to='/'>
                    Retourner a l acceuil
                </Button>
            </Segment.Inline>
        </Segment>
    )
}