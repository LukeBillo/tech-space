import React, { createContext, useState, FunctionComponent, useContext, useEffect } from 'react';
import { TechnologySpace } from '../shared/models/technology-space.model'
import { TechSpacesClient } from '../http/tech-spaces.http';
import { find, head } from 'lodash';

const defaultActiveSpaceName = 'popular';

const retrieveSpaces = async (setSpacesState: SpacesStateSetter) => {
    const spaces = await TechSpacesClient.getAll();
    const defaultActiveSpace = 
        find(spaces, space => space.name === defaultActiveSpaceName) ??
        head(spaces);

    if (defaultActiveSpace === undefined) {
        throw new Error("Looks like no spaces were loaded! Something's gone horribly wrong.");
    }

    setSpacesState({
        spaces: spaces,
        activeSpace: defaultActiveSpace
    });

    console.log('spaces loaded!');
    console.dir({
        spaces: spaces,
        activeSpace: defaultActiveSpace
    });
};

export type SpacesState = {
    spaces: TechnologySpace[],
    activeSpace: TechnologySpace
} | null;

export type SpacesStateSetter = (spacesState: SpacesState) => void;
export type SpacesStateHook = [SpacesState, SpacesStateSetter];

export const SpacesContext = createContext<SpacesStateHook>([null, () => {}]);

export const SpacesContextProvider: FunctionComponent = ({ children }) => {
    const [spacesState, setSpacesState] = useState<SpacesState>(null);

    useEffect(() => {
        if (!spacesState?.spaces) {
            retrieveSpaces(setSpacesState);
        }
      }, [spacesState]);

    return (
        <SpacesContext.Provider value={[spacesState, setSpacesState]}>
            {children}
        </SpacesContext.Provider>
    );
};

export const useSpaces = () => {
    const [spacesState, setSpacesState] = useContext(SpacesContext);

    const waitForSpacesToLoad = async () => {
        while (!spacesState) {
            await new Promise(resolve => setTimeout(resolve, 500));
        }
    }

    const setActiveSpace = (newActiveSpace: TechnologySpace) => {
        if (spacesState === null) {
            return;
        }

        setSpacesState({ ...spacesState, activeSpace: newActiveSpace })
    }

    return {
        spaces: spacesState?.spaces,
        activeSpace: spacesState?.activeSpace,
        waitForSpacesToLoad,
        setActiveSpace,
    }
};