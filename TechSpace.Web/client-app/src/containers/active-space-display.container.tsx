import React, { FunctionComponent, useEffect } from "react";
import { Router, useParams } from "react-router-dom";
import { SpaceDisplay } from "../components/content-space/space-display.component";
import { Loader } from "../components/shared/loading/loader.component";
import { useActiveSpace } from "../hooks/active-space.context";
import { useSpaces } from "../hooks/spaces.context";

type DisplayPostRouteParams = {
    spaceId: string;
};

export const ActiveSpaceDisplay: FunctionComponent = () => {
    const { spaceId } = useParams<DisplayPostRouteParams>();
    const { spaces } = useSpaces();
    const { activeSpace, postsForActiveSpace, setActiveSpace } = useActiveSpace();

    useEffect(() => {
        if (spaceId === activeSpace?.identifier) {
            return;
        }

        const space = spaces.find(space => space.identifier === spaceId);
        if (!space) {
            return;
        }

        setActiveSpace(space);
    }, [spaceId, spaces, setActiveSpace])

    return (activeSpace && postsForActiveSpace ?
        (
            <div className={"ActiveSpaceDisplay"}>
                <div className="viewing-title text-center">
                    <h4>You're viewing...</h4>
                    <h2>{activeSpace.name}</h2>
                </div>
                <SpaceDisplay space={activeSpace} posts={postsForActiveSpace} />
            </div>
        ) :
        <Loader />
    );
};
