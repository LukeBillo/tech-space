import React, { FunctionComponent } from "react";
import { BrowserRouter } from "react-router-dom";
import { ContentSpace } from "../content-space/content-space.component";
import { SideBar } from "../shared/sidebar/sidebar.component";

export const HomePage: FunctionComponent = () => (
  <div className="HomePage max-w-full h-screen text-white bg-secondary-dark">
    <div className={"container max-w-full h-full flex flex-row"}>
      <BrowserRouter>
        <SideBar />
        <ContentSpace />
      </BrowserRouter>
    </div>
  </div>
);
