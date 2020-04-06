import React, { useContext } from "react";
import { Form as FinalForm, Field } from "react-final-form";
import { Form, Button, Label, Header } from "semantic-ui-react";
import TextInput from "../../app/common/form/TextInput";
import { RootStoreContext } from "../../app/stores/rootStore";
import { IUserFormValues } from "../../app/models/user";
import { FORM_ERROR } from "final-form";

// const validate = combineValidators({
//   email: isRequired
// })

const RegisterForm = () => {
    const rootStore = useContext(RootStoreContext);
    const {register} = rootStore.userStore;
  return (
    <FinalForm
      onSubmit={(values: IUserFormValues) => register(values).catch(error => ({
        [FORM_ERROR]:error
      }))}
      render={({ handleSubmit, submitting, form, submitError}) => (
        <Form onSubmit={handleSubmit}>
          <Header as='h2' content='Sign up to activities' color='teal' textAlign='center'/>
          <Field name="username" component={TextInput} placeholder="Username" />
          <Field name="displayName" component={TextInput} placeholder="Display Name" />
          <Field name="email" component={TextInput} placeholder="Email" />
          <Field
            name="password"
            component={TextInput}
            placeholder="Password"
            type="password"
          />
          {submitError && <Label color='red' basic content={submitError.statusText}/>}
          {/* fluid để cho cái nút bằng với khung input */}
          <Button loading={submitting} color='teal' content="Register" fluid/>
        </Form>
      )}
    />
  );
};

export default RegisterForm;
