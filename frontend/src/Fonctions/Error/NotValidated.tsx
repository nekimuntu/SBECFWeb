import { observer } from "mobx-react";
import { Link } from "react-router-dom";
import { Button, Header, Icon, Message, Segment } from "semantic-ui-react";
interface Props{
    composant:string
}
function NotValidated(composant:Props){
    return(
        <Segment placeholder>
            <Header icon>
                <Icon name='edit outline' />
                Oops - N'oublize pas de valider {composant.composant} ...!
            </Header>
            <Segment.Inline>
                <Button >
                    x
                </Button>
            </Segment.Inline>
        </Segment>
    )
}
export default observer(NotValidated);