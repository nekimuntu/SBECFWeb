import { ErrorMessage, Form, Formik } from "formik";
import { observer } from "mobx-react"
import { Button, Header, Label } from "semantic-ui-react";
import MyTextInput from "../Commun/MyTextInput";
import { useEffect } from "react";
import { useStore } from "../../Fonctions/Store/store";
import { router } from "../../Fonctions/Routes/Routes";
import { Link } from "react-router-dom";
import RegisterForm from "./RegisterForm";

export default observer(function LoginForm() {
    const {usersStore,modalStore} = useStore();
    return (<>
        <Formik
            initialValues={{ email: "", password: "", error: null }}
            onSubmit={(values, { setErrors }) =>{
                      (usersStore.login(values))
                                    .catch((error) => setErrors({ error: "Invalid username or password"  }))
                        router.navigate("/");
                }
            }
        >
            {({ handleSubmit, isSubmitting, errors,dirty }) => {
                return (
                    
                    <Form title="Connexion"
                        className="ui form"
                        onSubmit={handleSubmit}
                        autoComplete="off">
                        <Header as="h2"  content="Connection" color="teal" textAling="right" />
                        
                        <MyTextInput placeholder="email" name="email" />
                        <MyTextInput placeholder="Password" name="password" type="password" />
                        <Label as={Link} onClick={()=>modalStore.openModal(<RegisterForm />)} content="MdP Oublie"  />
                        <Label as={Link} onClick={()=>modalStore.openModal(<RegisterForm />)} content="Creer un compte" />
                        
                        <ErrorMessage
                            name="error" render={() => <Label style={{ marginBottom: 10 }} content={errors.error} basic color="red" />} />
                        <Button loading={usersStore.isLoggedIn} positive content="login" type="submit" fluid />
                    </Form>
                );
            }}
        </Formik>
    </>)
})