import React, { createContext, Dispatch, FunctionComponent, Reducer, useContext, useReducer } from 'react';
import { TechnologySpace } from '../../shared/models/technology-space.model'
import { TechnologySpacePost } from '../../shared/models/technology-space-post.model';
import { ActiveSpaceAction, ActiveSpaceReducer } from './active-space.reducer';

export type ActiveSpaceState = {
    activeSpace: TechnologySpace,
    posts: TechnologySpacePost[],
    isLoading: boolean
} | null;


export const ActiveSpaceContext = createContext<[ActiveSpaceState, Dispatch<ActiveSpaceAction>] | null>(null);

export const ActiveSpaceContextProvider: FunctionComponent = ({ children }) => {
    const activeSpaceReducer = useReducer(ActiveSpaceReducer, null as ActiveSpaceState);

    return (
        <ActiveSpaceContext.Provider value={activeSpaceReducer}>
            {children}
        </ActiveSpaceContext.Provider>
    );
};

export const useActiveSpaceReducer = () => {
    const context = useContext(ActiveSpaceContext);
    if (context === null) {
        throw "";
    }

    const [state, dispatch] = context;

    return {
        state,
        dispatch
    };
}