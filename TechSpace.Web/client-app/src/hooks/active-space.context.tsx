import React, { createContext, useState, FunctionComponent, useContext } from 'react';
import { TechSpacesPostsClient } from "../http/tech-spaces-posts.http";
import { TechnologySpace } from '../models/technology-space.model';
import { TechnologySpacePost } from '../models/technology-space-post.model';

export type ActiveSpaceState = {
	activeSpace: TechnologySpace | null;
	postsForActiveSpace: TechnologySpacePost[];
};

export interface ActiveSpaceOperations {
	setActiveSpace(activeSpace: TechnologySpace): Promise<void>;
}

export type ActiveSpaceStateSetter = (spacesState: ActiveSpaceState) => void;
export type ActiveSpaceStateHook = [ActiveSpaceState, ActiveSpaceStateSetter];

export type ActiveSpaceHook = ActiveSpaceState & ActiveSpaceOperations;

const ActiveSpaceContext = createContext<ActiveSpaceHook | null>(null);

export function useProvideActiveSpace(): ActiveSpaceHook {
	const [activeSpaceState, setActiveSpaceState] = useState<ActiveSpaceState>({
		activeSpace: null,
		postsForActiveSpace: [],
	});

	const setActiveSpace = async (activeSpace: TechnologySpace) => {
		const posts = await TechSpacesPostsClient.getAllForSpace(activeSpace.identifier);
		setActiveSpaceState({ ...activeSpaceState, activeSpace, postsForActiveSpace: posts });
	};

	return {
		...activeSpaceState,
		setActiveSpace,
	};
}

export const ProvideActiveSpace: FunctionComponent = ({ children }) => {
	const activeSpaceHook = useProvideActiveSpace();

	return (
		<ActiveSpaceContext.Provider value={activeSpaceHook}>
			{children}
		</ActiveSpaceContext.Provider>);
};

export const useActiveSpace = (): ActiveSpaceHook => {
    const activeSpaceHook = useContext(ActiveSpaceContext);
    
	if (activeSpaceHook === null) {
		throw new Error("ActiveSpaceContext did not contain the hook- perhaps you didn't provide the ActiveSpaceContext?");
	}

	return activeSpaceHook;
};
