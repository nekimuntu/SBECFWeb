import { ErrorMessage, Form, Formik } from "formik";
import { observer } from "mobx-react"
import { Button, Header, Label } from "semantic-ui-react";
import MyTextInput from "../Commun/MyTextInput";
import { useStore } from "../../Fonctions/Store/store";

export default observer(function SideBarLoginForm() {
    const { usersStore } = useStore();
    return (<>

        <Formik
            initialValues={{ email: "", password: "", error: null }}
            onSubmit={(values, { setErrors }) =>
                console.log(values)
                // (usersStore.login(values)).catch((error) => setErrors({ error: "Invalid username or password" })
            }
        >
            {({ handleSubmit, isSubmitting, errors }) => {
                return (
                    <Form
                        className="ui form"
                        onSubmit={handleSubmit}
                        autoComplete="off">

                        <Header as="h2" content="Connectez vous" color="teal" textAling="center" />
                        <MyTextInput placeholder="email" name="email" />
                        <MyTextInput placeholder="Password" name="password" type="password" />
                        <ErrorMessage
                            name="error" render={() => <Label style={{ marginBottom: 10 }} content={errors.error} basic color="red" />} />
                        <Button loading={isSubmitting} positive content="login" type="submit" fluid />
                    </Form>
                );
            }}
        </Formik>

    </>)
})





