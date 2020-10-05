import React from "react";
import { SideBar } from "./components/sidebar/sidebar.component";
import { ContentSpace } from "./components/content-space/content-space.component";
import './tailwind.output.css'
import { ProvideSpaces } from "./state/spaces/spaces.context";

const App = () => {
  return (
    <div className="App max-w-full h-screen text-white bg-secondary-dark">
      <div className={"container h-full flex flex-row"}>
        <ProvideSpaces>
          <SideBar />
          <ContentSpace />
        </ProvideSpaces>
      </div>
    </div>
  );
}

export default App;
