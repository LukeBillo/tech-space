import React, { FunctionComponent } from "react";
import './navbar.css';

export const NavBar: FunctionComponent = () => {
    return (
        <div className={"NavBar bg-gray-800 shadow-lg flex align-middle my-auto"}>
            <h1>TechSpace</h1>
        </div>
    );
}