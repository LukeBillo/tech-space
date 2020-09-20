import React from "react";
import { SideBar } from "./components/sidebar/sidebar.component";
import { ContentSpace } from "./components/content-space/content-space.component";
import { SpacesContextProvider } from "./state/spaces.state";
import './tailwind.output.css'

const App = () => {
  return (
    <div className="App max-w-full h-screen text-white bg-secondary-dark">
      <div className={"container h-full flex flex-row"}>
        <SpacesContextProvider>
          <SideBar />
          <ContentSpace />
        </SpacesContextProvider>
      </div>
    </div>
  );
}

export default App;
