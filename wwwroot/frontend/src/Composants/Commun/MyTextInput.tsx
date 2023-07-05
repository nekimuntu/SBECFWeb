import { useField } from 'formik';
import React from 'react';
import { Form, Label } from 'semantic-ui-react';

interface Props{
    placeholder: string,
    name:string,
    label?:string,
    type?:string
    id?:string
}

export default function MyTextInput(props:Props){
    const [field,meta]=useField(props.name);
    // console.log(" name is "+field.name +"/ meta value :"+meta.value)
    
    // console.log("props "+props.name)
    // console.log("...field is "+useField(props.name))
    return(
        <Form.Field  error={ meta.touched && !!meta.error} >
            
            <input {...field} {...props} />
            {
                meta.touched && meta.error 
                ? (<Label basic color='red'>{meta.error}</Label>)
                : null
            }
        </Form.Field>
    )
}