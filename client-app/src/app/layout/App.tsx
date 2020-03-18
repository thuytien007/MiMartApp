import React, { useState, useEffect, Fragment, SyntheticEvent } from "react";
import {Container } from "semantic-ui-react";
import NavBar from "../../features/nav/NavBar";
import { IActivity } from "../models/activity";
import ActivityDashboard from "../../features/activities/dashboard/ActivityDashboard";
import agent from "../api/agent";
import { LoadingComponent } from "./LoadingComponent";

//sử dụng React Hooks, IActivities là interface trong model
const App = () => {
  const [activities, setActivities] = useState<IActivity[]>([]);
  //dấu | có nghĩa là selectedActivity có thể là activity hoặc null
  const [selectedActivity, setSelectedActivity] = useState<IActivity | null>(
    null
  );

  //đây là khi click nút View bên tay phải hiện ra detail của activity đó
  const handleSelectActivity = (id: string) => {
    setSelectedActivity(activities.filter(a => a.id === id)[0]);
    //dòng này để khi click qua edit hay create vẫn click view show lại dc detail
    setEditMode(false);
  };
  //khi nhấn nút CreateActivity thì ra cái form
  const handleOpenCreateForm = () => {
    setSelectedActivity(null);
    setEditMode(true);
  };

  const [editMode, setEditMode] = useState(false);
  //để tạo cái hinh loading quay quay
  const[loading, setLoading] = useState(true);
  const[submitting, setSubmitting] = useState(false);
  const[target, setTarget] = useState('');

  //xử lý khi click vô nút tạo mới 1 activity
  const handleCreateActivity = (activity: IActivity) => {
    setSubmitting(true);
    //xử lý khi create lưu xuống db
    agent.Activities.create(activity).then(() =>{
      setActivities([...activities, activity])
      //xử lý khi edit nó k tạo ra cái mới
      setSelectedActivity(activity);
      setEditMode(false);
    }).then(() => setSubmitting(false));
  };

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
    agent.Activities.list().then(respone => {
      let activities: IActivity[] = [];
      respone.forEach((activity) => {
        activity.date = activity.date.split(".")[0];
        activities.push(activity);
      });
      setActivities(activities);
    }).then(() => setLoading(false));
    //truyền t.so thứ 2 là mảng rỗng để useEffect gọi 1 lần duy nhất, k render lại
    //vì useEffect như componentDidMount, sau khi get từ API sẽ set vào và quay lại get tiếp
  }, []);

  if(loading)
    return <LoadingComponent content = 'Loading activities...' />
    
  return (
    <Fragment>
      <NavBar openCreateForm={handleOpenCreateForm} />
      <Container style={{ marginTop: "7em" }}>
        <ActivityDashboard
          activities={activities}
          selectActivity={handleSelectActivity}
          selectedActivity={selectedActivity}
          editMode={editMode}
          setEditMode={setEditMode}
          setSelectedActivity={setSelectedActivity}
          createActivity={handleCreateActivity}
          editActivity={handleEditActivity}
          deleteActivity={handleDeleteActivity}
          submitting={submitting}
          target={target}
        />
      </Container>
    </Fragment>
  );
};

export default App;
