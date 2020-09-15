import { TechnologySpace } from "../../../shared/models/technology-space.model";
import React, { FunctionComponent } from "react";

export type SpaceNavItemProps = {
    space: TechnologySpace,
    isActive: boolean
}

export const SpaceNavItem: FunctionComponent<SpaceNavItemProps> = (props: SpaceNavItemProps) => {
    const displayName = props.isActive ?
        `${props.space.name} - Active` :
        props.space.name;

    return (
        <div className={"SpaceNavItem pl-4 py-2"}>
            <a href={'#'} className={"hover:bg-gray cursor-pointer"}>{displayName}</a>
        </div>
    );
}