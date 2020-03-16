import React from "react";
import { Menu, Container, Button } from "semantic-ui-react";

//gõ rafc tab ra đoạn code mẫu rồi qua semantic chọn style mẫu bỏ vô
interface IProps{
  openCreateForm: () => void;
}

export const NavBar:React.FC<IProps> = ({openCreateForm}) => {
  return (
    <Menu fixed="top" inverted>
      <Container>
        <Menu.Item header>
          <img src="/assets/logo.png" alt="logo" style={{marginRight:'10px'}}/>
          Reactivites
        </Menu.Item>
        <Menu.Item name="Activities" />
        <Menu.Item>
          <Button onClick={openCreateForm} positive content="Create Activity" />
        </Menu.Item>
      </Container>
    </Menu>
  );
};

export default NavBar;
