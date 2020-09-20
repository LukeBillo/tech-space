import React from "react";
import { SideBar } from "./components/sidebar/sidebar.component";
import { ContentSpace } from "./components/content-space/content-space.component";
import './tailwind.output.css'
import { ActiveSpaceContextProvider } from "./state/active-space/active-space.context";

const App = () => {
  return (
    <div className="App max-w-full h-screen text-white bg-secondary-dark">
      <div className={"container h-full flex flex-row"}>
        <ActiveSpaceContextProvider>
          <SideBar />
          <ContentSpace />
        </ActiveSpaceContextProvider>
      </div>
    </div>
  );
}

export default App;
