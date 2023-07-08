import { ErrorMessage, Form, Formik } from "formik";
import { observer } from "mobx-react";
import { Button, Header, Label } from "semantic-ui-react";
import MyTextInput from "../Commun/MyTextInput";
import { useStore } from "../../Fonctions/Store/store";
import { router } from "../../Fonctions/Routes/Routes";
import { UserFormValues } from "../../Modele/UserDTO";
import * as Yup from 'yup'

export default observer(function RegisterForm() {
    const { usersStore } = useStore();
    const userFormValues: UserFormValues = {
        nom: "",
        prenom: "",
        username: "",
        email: "",
        password: "",
        error: null,

    }
    return (<>
        <Formik
            initialValues={userFormValues}
            onSubmit={(values, { setErrors }) => {
                console.log(values)
                usersStore.register(values)
                    .catch((error) => setErrors({error}));
                router.navigate("/");
                }
            }
            validationSchema={Yup.object({
                nom:Yup.string().required(),
                prenom:Yup.string().required(),
                username:Yup.string().required(),
                email:Yup.string().required().email(),
                password:Yup.string().required()
            })}
        >
            {({ handleSubmit, isSubmitting, errors, dirty }) => {
                return (
                    <Form title="creer un compte"
                        className="ui form error"
                        onSubmit={handleSubmit}
                        autoComplete="off">
                        <Header as="h2" content="Creer un Compte pour parier" color="teal" textAling="right" />
                        <MyTextInput placeholder="Prenom" name="prenom" />
                        <MyTextInput placeholder="Nom" name="nom" />
                        <MyTextInput placeholder="username" name="username" />
                        <MyTextInput placeholder="email" name="email" />
                        <MyTextInput placeholder="Password" name="password" type="password" />
                        <ErrorMessage
                            name="error" render={() => <Label content={errors.error} color="red" /> }
                        />
                        <Button loading={isSubmitting} disabled={!dirty && !!errors} positive content="Register" type="submit" fluid />
                    </Form>
                )
            }}
        </Formik>
    </>)
})