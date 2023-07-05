import { observer } from "mobx-react"
import { Button, Checkbox, CheckboxProps, Form, Header, Label, Radio, Segment } from "semantic-ui-react"
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

interface Props {
    jeu: Jeu,
    equipes: Equipe[],
    pariId: number
    //TODO: rajouter utilisateur
}

export default observer(function SideBarMiseForm(props: Props) {
    const { pariStore, modalStore } = useStore();
    const { jeu, equipes, pariId } = { ...props }


    const [statePari, setPari] = useState<Pari>(
        {
            id: pariStore.firstPari ? null : pariStore.lePari?.id!,
            matchId: jeu.id,
            jeu: jeu,
            userId: pariStore.firstPari ? "test" : pariStore.lePari?.userId!,
            utilisateur: pariStore.firstPari ? undefined : pariStore.lePari?.utilisateur,
            montantMise: pariStore.firstPari ? 0 : pariStore.lePari?.montantMise!,
            montantGagne: 0,
            dateMise: new Date(),
            equipeId: pariStore.firstPari ? 0 : pariStore.lePari?.equipeId!,
            equipe: pariStore.firstPari ? undefined : pariStore.lePari?.equipe!,
        }
    );

    useEffect(() => {
        pariStore.getPariByMatch(jeu.id);
        if (!pariStore.firstPari)
            setPari(pariStore.lePari!)
    }, [pariStore, pariStore.firstPari]);

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
        console.log(pariDto);
        //eslint-disable-next-line no-restricted-globals
        if (confirm("Confirmer la mise?")) {
            if (pariStore.firstPari) {
                pariStore.setSubmit(true);
                pariStore.savePari(undefined,pariDto);
            }
        }
        if (!boxIsSelected) {
            console.log(boxIsSelected)
            modalStore.openModal(<NotValidated composant={"Equipe"} />)
        }
    }


    return (<>
        
        <Segment inverted>
            <Header textAlign="center" content="Miser sur votre equipe" />
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
                            <Field id={2} value={`${jeu.equipeBId}`} type="radio" name="equipeId" /> {jeu.equipeB.nom}
                        </Label>
                        <Label  >
                            <Field id={1} value={`${jeu.equipeBId}`} type="radio" name="equipeId" /> {jeu.equipeA.nom}
                        </Label>

                        {errors.equipeId
                            ? (<Label basic color='red'>{errors.equipeId}</Label>)
                            : null}

                        <Button disabled={!isValid || !dirty}
                            loading={pariStore.loading}
                            positive type='submit' >
                            Valider
                        </Button>
                    </Form>)}
            </Formik>
        </Segment>
    </>)
})