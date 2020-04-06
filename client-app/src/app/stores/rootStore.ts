//do có nhiều store cần sài chung createContext, nên tạo chung 1 rootStore
import ActivityStore from './activityStore';
import UserStore from './userStore';
import { createContext } from 'react';
import { configure } from 'mobx';
import CommonStore from './commonStore';
import ModalStore from './modalStore';

configure({ enforceActions: "always" });

export class RootStore{
    activityStore: ActivityStore;
    userStore: UserStore;
    commonStore: CommonStore;
    modalStore: ModalStore;

    constructor(){
        //this là chỉ đến hàm khởi tạo ở lớp bên kia
        this.activityStore = new ActivityStore(this);
        this.userStore = new UserStore(this);
        this.commonStore = new CommonStore(this);
        this.modalStore = new ModalStore(this);
    }
}

export const RootStoreContext = createContext(new RootStore());