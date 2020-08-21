import React from "react";
import { SideBar } from "./components/sidebar/sidebar.component";
import { ContentSpace } from "./components/content-space/content-space.component";
import { NavBar } from "./components/navbar/navbar.component";

const App = () => {
  return (
    <div className="App max-w-full max-h-full bg-white">
      <NavBar />
      <div className={"container flex flex-row"}>
        <SideBar />
        <ContentSpace />
      </div>
    </div>
  );
}

export default App;
