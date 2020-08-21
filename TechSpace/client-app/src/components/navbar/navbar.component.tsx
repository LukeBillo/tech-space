import React, { FunctionComponent } from "react";
import './navbar.css';

export const NavBar: FunctionComponent = () => {
    return (
        <div className={"NavBar border-b shadow-lg flex align-middle"}>
            <h1>TechSpace</h1>
        </div>
    );
}