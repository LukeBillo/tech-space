import React from 'react';
import './App.scss';
import {SideBar} from "./components/sidebar/sidebar.component";
import {ContentContainer} from "./components/content-container/content-container.component";

function App() {
  return (
    <div className="App">
        <SideBar />
        <ContentContainer />
    </div>
  );
}

export default App;
