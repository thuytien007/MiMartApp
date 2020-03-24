import {observable, action, computed} from 'mobx';
import { createContext } from 'react';
import { IActivity } from '../models/activity';
import agent from '../api/agent';

class ActivityStore{
    //observable là biến
    @observable activities: IActivity[] = [];
    @observable loadingInitial = false;
    @observable selectedActivity: IActivity | undefined;
    @observable editMode = false;
    @observable submitting = false;

    //computed để xử lý khi có dl sẵn vd sắp xếp
    @computed get activitiesByDate(){
        return this.activities.sort((a, b) => Date.parse(a.date) - Date.parse(b.date));
    }

    //action là hàm
    @action loadActivities = async () =>{
        this.loadingInitial = true;
        try{
            const activities = await agent.Activities.list();
            activities.forEach((activity) => {
                activity.date = activity.date.split(".")[0];
                this.activities.push(activity);
              });
              this.loadingInitial = false;
        }catch(error){
            console.log(error);
            this.loadingInitial = false;
        }
    };

    //đây là khi click nút View bên tay phải hiện ra detail của activity đó
    @action selectActivity = (id: string) =>{
        this.selectedActivity = this.activities.find(a => a.id === id);
        //dòng này để khi click qua edit hay create vẫn click view show lại dc detail
        this.editMode = false;
    };

    @action createActivity = async (activity:IActivity) =>{
        this.submitting = true;
        try{
            await agent.Activities.create(activity);
            this.activities.push(activity);
            this.editMode = false;
            this.submitting = false;
        }catch(error){
            this.submitting = false;
            console.log(error);
        }
    }

    //khi nhấn nút create tạo ra cái form
    @action openCreateForm =() =>{
        this.editMode = true;
        this.selectedActivity = undefined;
    }
}

export default createContext(new ActivityStore());