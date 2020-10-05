import React, { createContext, useState, FunctionComponent, useContext, useEffect } from 'react';
import { TechnologySpace } from '../../shared/models/technology-space.model'
import { TechSpacesClient } from '../../http/tech-spaces.http'
import { TechnologySpacePost } from '../../shared/models/technology-space-post.model';
import { TechSpacesPostsClient } from '../../http/tech-spaces-posts.http';

const retrieveSpaces = async (currentState: ) => {
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
    activeSpace: TechnologySpace | null
    postsForActiveSpace: TechnologySpacePost[]
};

export interface SpacesOperations {
    setActiveSpace(activeSpace: TechnologySpace): void
}

export type SpacesStateSetter = (spacesState: SpacesState) => void;
export type SpacesStateHook = [SpacesState, SpacesStateSetter];

export type SpacesHook =
    SpacesState &
    SpacesOperations;

export type InternalSpacesHook =
    SpacesState &
    SpacesOperations &
    { setSpacesState: SpacesStateSetter };

const SpacesContext = createContext<InternalSpacesHook | null>(null);

export function useProvideSpaces(): InternalSpacesHook {
    const [spacesState, setSpacesState] = useState<SpacesState>({
        spaces: [],
        activeSpace: null,
        postsForActiveSpace: []
    });

    const setActiveSpace = (activeSpace: TechnologySpace) => {
        setSpacesState({ ...spacesState, activeSpace });
        TechSpacesPostsClient
            .get(activeSpace.name)
            .then(posts => {
                setSpacesState({ ...spacesState, postsForActiveSpace: posts });
            });
    }

    return {
        ...spacesState,
        setActiveSpace,
        setSpacesState
    }
};

export const ProvideSpaces: FunctionComponent = ({ children }) => {
    const spacesHook = useProvideSpaces();

    return (
        <SpacesContext.Provider value={spacesHook}>
            {children}
        </SpacesContext.Provider>
    );
};

export const useSpaces = (): SpacesHook => {
    const { spacesHook = useContext(SpacesContext);
    if (spacesHook === null) {
        throw new Error("SpacesContext did not contain the hook- perhaps you didn't provide the SpacesContext?");
    }

    console.log('providing spaces...');
    useEffect(() => {
        console.log('retrieving spaces');
        retrieveSpaces([spacesState, setSpacesState]);
    }, [spacesState]);

    return spacesHook;
}