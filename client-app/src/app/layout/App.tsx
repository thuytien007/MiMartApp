import React, { useState, useEffect, Fragment } from "react";
import axios from "axios";
import {Container } from "semantic-ui-react";
import NavBar from "../../features/nav/NavBar";
import { IActivity } from "../models/activity";
import ActivityDashboard from "../../features/activities/dashboard/ActivityDashboard";

//sử dụng React Hooks, IActivities là interface trong model
const App = () => {
  const [activities, setActivities] = useState<IActivity[]>([]);
  //dấu | có nghĩa là selectedActivity có thể là activity hoặc null
  const [selectedActivity, setSelectedActivity] = useState<IActivity | null>(
    null
  );

  const [editMode, setEditMode] = useState(false);

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

  //xử lý khi click vô nút tạo mới 1 activity
  const handleCreateActivity = (activity: IActivity) => {
    setActivities([...activities, activity]);
    //xử lý khi edit nó k tạo ra cái mới
    setSelectedActivity(activity);
    setEditMode(false);
  };

  //xử lý khi click vô nút eidt 1 activity
  const handleEditActivity = (activity: IActivity) => {
    setActivities([...activities.filter(a => a.id !== activity.id), activity]);
    //xử lý khi edit nó k tạo ra cái mới
    setSelectedActivity(activity);
    setEditMode(false);
  };

  //xử lý nút xóa
  const handleDeleteActivity = (id : string) =>{
    setActivities([...activities.filter(a => a.id !== id)])
  };

  useEffect(() => {
    axios.get<IActivity[]>("http://localhost:5000/api/activities").then(respone => {
      let activities: IActivity[] = [];
      respone.data.forEach(activity => {
        activity.date = activity.date.split(".")[0];
        activities.push(activity);
      });
      setActivities(activities);
    });
    //truyền t.so thứ 2 là mảng rỗng để useEffect gọi 1 lần duy nhất, k render lại
    //vì useEffect như componentDidMount, sau khi get từ API sẽ set vào và quay lại get tiếp
  }, []);
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
        />
      </Container>
    </Fragment>
  );
};

export default App;
