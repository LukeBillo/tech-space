import { useState, useEffect } from "react";
import { TechSpacesClient } from "../../../services/tech-spaces.service";
import { TechnologySpace } from "../../../models/technology-space.model";
import { LoadingSpaces } from "./loading-spaces.component";
import { SpaceNavItem } from "./space-nav-item.component";
import React from "react";

type SpacesSetter = React.Dispatch<React.SetStateAction<TechnologySpace[] | null>>;

const RetrieveSpaces = async (spacesSetter: SpacesSetter) => {
    const spaces = await TechSpacesClient.getAll();
    spacesSetter(spaces);
}

const ConstructSpaceNavItem = (technologySpace: TechnologySpace) => {
    return (<SpaceNavItem space={technologySpace} />);
}

export const SpacesSideNavigation = () => {
    const [spaces, setSpaces] = useState<Array<TechnologySpace> | null>(null);

    useEffect(() => {
        if (!spaces) {
            RetrieveSpaces(setSpaces);
        }
      }, [spaces]);

    return (
    <div className={"SpacesSideNavigation mx-8 my-2"}>
        <h2>Spaces</h2>
        <hr />
        {spaces ? 
            spaces.map(space => ConstructSpaceNavItem(space)) :
            <LoadingSpaces />}
    </div>)
}
