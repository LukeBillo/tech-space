import { TechnologySpace } from "../../../models/technology-space.model";
import React, { FunctionComponent } from "react";

export type SpaceNavItemProps = {
    space: TechnologySpace
}

export const SpaceNavItem: FunctionComponent<SpaceNavItemProps> = (props: SpaceNavItemProps) => {
    return (
        <div className={"SpaceNavItem pl-4 py-2"}>
            {props.space.name}
        </div>
    );
}