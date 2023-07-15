import { Card, Container } from "semantic-ui-react";

export default function UserDetails() {
    const details = {
        username: 'yannickNago',
        nom: 'Kimuntu',
        prenom: 'yannick',
        email: 'yannick@test.com'
    }
    return (<>
        <Container style={{ marginTop: '5em' }} >
            <Card
                image='/assets/pict/userProfile.png'
                header={`${details.nom} ${details.prenom}`}
                meta={details.username}
                description={`Mail : ${details.email}`}
                // extra={extra}
            />
        </Container>

    </>);
}