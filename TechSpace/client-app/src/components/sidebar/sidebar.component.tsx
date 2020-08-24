import React, { useState, useEffect, FunctionComponent } from "react";
import './sidebar.css';
import { SpacesSideNavigation } from "./spaces-side-navigation/spaces-side-navigation.component";

export const SideBar: FunctionComponent = () => {
    return (
    <div className={"SideBar max-h-screen"}>
        <SpacesSideNavigation />
    </div>
    );
}