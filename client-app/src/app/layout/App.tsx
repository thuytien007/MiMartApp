import React, { useState, useEffect, Fragment, SyntheticEvent, useContext } from "react";
import {Container } from "semantic-ui-react";
import NavBar from "../../features/nav/NavBar";
import { IActivity } from "../models/activity";
import ActivityDashboard from "../../features/activities/dashboard/ActivityDashboard";
import agent from "../api/agent";
import { LoadingComponent } from "./LoadingComponent";
import ActivityStore from "../stores/activityStore";
import {observer} from "mobx-react-lite";

//sử dụng React Hooks, IActivities là interface trong model
const App = () => {
  const activityStore = useContext(ActivityStore);
  const [activities, setActivities] = useState<IActivity[]>([]);
  //dấu | có nghĩa là selectedActivity có thể là activity hoặc null
  const [selectedActivity, setSelectedActivity] = useState<IActivity | null>(null);
  const [editMode, setEditMode] = useState(false);
  //để tạo cái hinh loading quay quay
  const[loading, setLoading] = useState(true);
  const[submitting, setSubmitting] = useState(false);
  const[target, setTarget] = useState('');

  //xử lý khi click vô nút eidt 1 activity
  const handleEditActivity = (activity: IActivity) => {
    setSubmitting(true);
    agent.Activities.update(activity).then(() =>{
      setActivities([...activities.filter(a => a.id !== activity.id), activity]);
      //xử lý khi edit nó k tạo ra cái mới
      setSelectedActivity(activity);
      setEditMode(false);
    }).then(() => setSubmitting(false));
  };

  //xử lý nút xóa
  const handleDeleteActivity = (event: SyntheticEvent<HTMLButtonElement>,id : string) =>{
    setSubmitting(true);
    setTarget(event.currentTarget.name);
    agent.Activities.delete(id).then(() =>{
      setActivities([...activities.filter(a => a.id !== id)])
    }).then(() => setSubmitting(false));
  };

  useEffect(() => {
    activityStore.loadActivities();
  }, [activityStore]);

  if(activityStore.loadingInitial)
    return <LoadingComponent content = 'Loading activities...' />
    
  return (
    <Fragment>
      <NavBar/>
      <Container style={{ marginTop: "7em" }}>
        <ActivityDashboard
          setEditMode={setEditMode}
          setSelectedActivity={setSelectedActivity}
          editActivity={handleEditActivity}
          deleteActivity={handleDeleteActivity}
          submitting={submitting}
          target={target}
        />
      </Container>
    </Fragment>
  );
};

export default observer(App);
