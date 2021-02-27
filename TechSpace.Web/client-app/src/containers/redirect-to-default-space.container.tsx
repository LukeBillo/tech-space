import { isEmpty, head } from "lodash";
import React, { useEffect } from "react";
import { FunctionComponent } from "react";
import { Redirect } from "react-router-dom";
import { useSpaces } from "../hooks/spaces.context";
import { useActiveSpace } from "../hooks/active-space.context";

export const RedirectToDefaultSpace: FunctionComponent = () => {
    const { spaces } = useSpaces();
    const { activeSpace, setActiveSpace } = useActiveSpace();

    useEffect(() => {
		if (!activeSpace && !isEmpty(spaces)) {
			setActiveSpace(head(spaces)!);
		}
	}, [spaces, activeSpace, setActiveSpace]);

    return (
        spaces && activeSpace &&
        <Redirect to={{ pathname: `/space/${activeSpace.identifier}` }} />
    );
}