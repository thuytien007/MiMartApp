import React, { Component } from "react";
import logo from "./logo.svg";
import "./App.css";
import axios from "axios";
import { Header, Icon } from "semantic-ui-react";
import { List } from "semantic-ui-react";

class App extends Component {
  state = {
    values: []
  };

  componentDidMount() {
    //chưa gọi API đang set cứng
    // this.setState({
    //   values: [
    //     { id: 1, name: "Value 101" },
    //     { id: 2, name: "Value 102" },
    //   ]
    // });
    //----------gọi API lấy thông qua axios trả về promise---------
    axios.get("http://localhost:5000/api/values").then(respone => {
      console.log(respone);
      this.setState({
        values: respone.data
      });
    });
  }
  render() {
    return (
      <div className="App">
        <Header as="h2" icon>
          <Icon name="users" />
          Account Settings
          <Header.Content>Reactivities</Header.Content>
          <img src={logo} className="App-logo" alt="logo" />
          <List>
            {this.state.values.map((value: any) => (
              <li key={value.id}>{value.name}</li>
            ))}
          </List>
        </Header>
      </div>
    );
  }
}

export default App;
