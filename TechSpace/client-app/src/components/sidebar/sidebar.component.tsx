import React, { useState, useEffect } from "react";
import './sidebar.css';
import { SpacesSideNavigation } from "./spaces-side-navigation/spaces-side-navigation.component";



export const SideBar = () => {
    return (
    <div className={"SideBar max-h-screen"}>
        <SpacesSideNavigation />
    </div>
    );
}