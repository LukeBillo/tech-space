import React, { createContext, useState, FunctionComponent, useContext, useEffect } from 'react';
import { TechnologySpace } from '../../shared/models/technology-space.model'
import { TechSpacesClient } from '../../http/tech-spaces.http'


const retrieveSpaces = async (spacesStateHook: SpacesStateHook) => {
    const [state, setState] = spacesStateHook;
    const spaces = await TechSpacesClient.getAll();

    setState({
        ...state,
        spaces: spaces,
    });

    console.log('spaces loaded!');
};

export type SpacesState = {
    spaces: TechnologySpace[],
} | null;

export type SpacesStateSetter = (spacesState: SpacesState) => void;
export type SpacesStateHook = [SpacesState, SpacesStateSetter];

export const SpacesContext = createContext<SpacesStateHook>([null, () => {}]);

export const SpacesContextProvider: FunctionComponent = ({ children }) => {
    const [spacesState, setSpacesState] = useState<SpacesState>(null);

    useEffect(() => {
        if (!spacesState?.spaces) {
            retrieveSpaces([spacesState, setSpacesState]);
        }
      }, [spacesState, setSpacesState]);

    return (
        <SpacesContext.Provider value={[spacesState, setSpacesState]}>
            {children}
        </SpacesContext.Provider>
    );
};

export const useSpacesState = () => {
    const [spacesState] = useContext(SpacesContext);

    if (spacesState === null) {
        return {
            spaces: []
        }   
    }

    return {
        spaces: spacesState.spaces
    }
};