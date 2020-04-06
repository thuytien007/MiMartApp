import React, { useState, FormEvent, useContext, useEffect } from "react";
import { Segment, Form, Button, Grid } from "semantic-ui-react";
import { IActivity } from "../../../app/models/activity";
import { observer } from "mobx-react-lite";
import { RouteComponentProps } from "react-router-dom";
import { Form as FinalForm, Field } from "react-final-form";
import { RootStoreContext } from "../../../app/stores/rootStore";
import TextInput from "../../../app/common/form/TextInput";

//react final form xử lý khi bỏ trống form k điền là nhắc đỏ

interface DetailParams {
  id: string;
}

const ActivityForm: React.FC<RouteComponentProps<DetailParams>> = ({
  match,
  history
}) => {
  const rootStore = useContext(RootStoreContext);
  const {
    submitting,
    activity: initialFormState,
    loadActivity,
    clearActivity
  } = rootStore.activityStore;

  const [activity, setActivity] = useState<IActivity>({
    id: "",
    title: "",
    category: "",
    description: "",
    date: "",
    city: "",
    venue: ""
  });

  useEffect(() => {
    if (match.params.id && activity.id.length === 0) {
      //dòng này dùng để khi đang đứng ở edit khi load lại trang nó cũng k mất đi
      loadActivity(match.params.id).then(
        () => initialFormState && setActivity(initialFormState)
      );
    }
    return () => {
      clearActivity();
    };
  }, [
    loadActivity,
    match.params.id,
    clearActivity,
    initialFormState,
    activity.id.length
  ]);

  //hàm xử lý khi nhấn nút submit
  // const handleSubmit = () => {
  //   //nếu id = 0 thì biết là tạo mới, không thì là user edit
  //   if (activity.id.length === 0) {
  //     let newActivity = {
  //       ...activity,
  //       id: uuid()
  //     };
  //     createActivity(newActivity).then(() =>
  //       history.push(`/activities/${newActivity.id}`)
  //     );
  //   } else {
  //     editActivity(activity).then(() =>
  //       history.push(`/activities/${activity.id}`)
  //     );
  //   }
  // };

  const handleFinalFormSubmit = (values: any) => {
    console.log(values);
  };
  //hàm này dùng để gõ chữ đc vào trong các form
  const handleInputChange = (
    event: FormEvent<HTMLInputElement | HTMLTextAreaElement>
  ) => {
    const { name, value } = event.currentTarget;
    setActivity({ ...activity, [name]: value });
  };

  return (
    <Grid>
      <Grid.Column width={10}>
        <Segment clearing>
          <FinalForm
            onSubmit={handleFinalFormSubmit}
            render={({ handleSubmit }) => (
              <Form onSubmit={handleSubmit}>
                <Field
                  name="title"
                  placeholder="Titile"
                  value={activity.title}
                  component={TextInput}
                />
                <Form.TextArea
                  onChange={handleInputChange}
                  name="description"
                  row={2}
                  placeholder="Description"
                  value={activity.description}
                />
                <Form.Input
                  onChange={handleInputChange}
                  name="category"
                  placeholder="Category"
                  value={activity.category}
                />
                <Form.Input
                  onChange={handleInputChange}
                  name="date"
                  type="datetime-local"
                  placeholder="Date"
                  value={activity.date}
                />
                <Form.Input
                  onChange={handleInputChange}
                  name="city"
                  placeholder="City"
                  value={activity.city}
                />
                <Form.Input
                  onChange={handleInputChange}
                  name="venue"
                  placeholder="Venue"
                  value={activity.venue}
                />
                <Button
                  loading={submitting}
                  floated="right"
                  positive
                  type="submit"
                  content="Submit"
                />
                <Button
                  onClick={() => history.push("/activities")}
                  floated="right"
                  type="button"
                  content="Cancel"
                />
              </Form>
            )}
          />
        </Segment>
      </Grid.Column>
    </Grid>
  );
};

export default observer(ActivityForm);
