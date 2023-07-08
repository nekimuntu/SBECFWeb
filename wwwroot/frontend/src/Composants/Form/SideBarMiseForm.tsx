import { observer } from "mobx-react"
import { Button, Checkbox, CheckboxProps, Container, Form, Header, Label, Radio, Segment } from "semantic-ui-react"
import * as Yup from 'yup'
import MyTextInput from "../Commun/MyTextInput"
import { Field, Formik } from "formik"
import Pari from "../../Modele/Pari"
import { FormEvent, useEffect, useState } from "react"
import { useStore } from "../../Fonctions/Store/store"
import Jeu from "../../Modele/Jeu"
import Utilisateur from "../../Modele/Utilisateur"
import Equipe from "../../Modele/Equipe"
import NotValidated from "../../Fonctions/Error/NotValidated"
import PariDTO from "../../Modele/PariDTO"
import { toast } from "react-toastify"

interface Props {
    jeu: Jeu,
    equipes: Equipe[],
    pariId: number
    //TODO: rajouter utilisateur
}

export default observer(function SideBarMiseForm(props: Props) {
    const { pariStore, modalStore, usersStore } = useStore();
    const { jeu, equipes, pariId } = { ...props }

    useEffect(() => {
        if (usersStore.isLoggedIn)
            pariStore.getPariByMatch(jeu.id, usersStore.user?.email!);
        if (!pariStore.firstPari)
            setPari(pariStore.lePari!)
    }, [pariStore, pariStore.firstPari]);

    const [statePari, setPari] = useState<Pari>(
        {
            id: pariStore.firstPari ? null : pariStore.lePari?.id!,
            matchId: jeu.id,
            jeu: jeu,
            userId: pariStore.firstPari ? "" : pariStore.lePari?.userId!,
            utilisateur: pariStore.firstPari ? undefined : pariStore.lePari?.utilisateur,
            montantMise: pariStore.firstPari ? 0 : pariStore.lePari?.montantMise!,
            montantGagne: 0,
            dateMise: pariStore.firstPari ? new Date() : pariStore.lePari?.dateMise!,
            equipeId: pariStore.firstPari ? 0 : pariStore.lePari?.equipeId!,
            equipe: pariStore.firstPari ? undefined : pariStore.lePari?.equipe!,
        }
    );

   

    const validationSchema = Yup.object({
        montantMise: Yup.number().min(1, "la mise doit etre superieur a 1 euro").required("Entrez un chiffre"),
        equipeId: Yup.number().required("Selectionnez au moins une equipe"),
    });

    const [boxIsSelected, setBoxSelected] = useState(false);
    const boxSelected = () => {
        setBoxSelected(true);
    }

    const handleSubmit = (pari: Pari) => {
        const pariDto: PariDTO = {
            matchId: pari.matchId,
            userId: pari.userId,
            montantMise: pari.montantMise,
            montantGagne: pari.montantGagne,
            dateMise: pari.dateMise,
            equipeId: pari.equipeId
        }
        // console.log(pariDto);
        if (!boxIsSelected) {

            toast.warning("Veuillez selectionner une equipe");
            // modalStore.openModal(<NotValidated composant={"Equipe"} />)
        }
        //eslint-disable-next-line no-restricted-globals
        if (confirm("Confirmer la mise?")) {
            if (pariStore.firstPari) {
                pariStore.setSubmit(true);
                pariStore.savePari(undefined, pariDto).catch(err => toast.error(err));
            }
        }
    }

    return (<>

        <Segment inverted>
            <Header content="Miser sur votre equipe" />
            <Formik
                validationSchema={validationSchema}
                initialValues={statePari}
                onSubmit={(values) => handleSubmit(values)}
            >
                {({ handleSubmit, isValid, isSubmitting, dirty, errors }) =>
                (
                    <Form inverted className="ui form" onSubmit={handleSubmit} >
                        <MyTextInput name="montantMise" label='Mise ' placeholder='Mise' />
                        <Label>
                            <Field id={2} onClick={boxSelected} value={`${jeu.equipeBId}`} type="radio" name="equipeId" /> {jeu.equipeB.nom}
                        </Label>
                        <Label  >
                            <Field id={1} onClick={boxSelected} value={`${jeu.equipeBId}`} type="radio" name="equipeId" /> {jeu.equipeA.nom}
                        </Label>
                        {errors.equipeId
                            ? (<Label basic color='red'>{errors.equipeId}</Label>)
                            : null
                        }
                        <Container style={{ marginTop: '2em' }}>
                            <Button disabled={!isValid || !dirty}
                                loading={pariStore.loading}
                                positive type='submit' >
                                Parier
                            </Button>
                        </Container>
                    </Form>)}
            </Formik>
        </Segment>
    </>)
})