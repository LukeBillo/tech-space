import React, { createContext, useState, FunctionComponent, useContext, useEffect } from 'react';
import { TechnologySpace } from '../models/technology-space.model';
import { TechSpacesClient } from '../http/tech-spaces.http';
import { TechnologySpacePost } from '../models/technology-space-post.model';
import { TechSpacesPostsClient } from '../http/tech-spaces-posts.http';
import { head, isEmpty } from 'lodash';

export type SpacesState = {
	spaces: TechnologySpace[];
	activeSpace: TechnologySpace | null;
	postsForActiveSpace: TechnologySpacePost[];
};

export interface SpacesOperations {
	setActiveSpace(activeSpace: TechnologySpace): Promise<void>;
	fetchAllSpaces(): Promise<void>;
}

export type SpacesStateSetter = (spacesState: SpacesState) => void;
export type SpacesStateHook = [SpacesState, SpacesStateSetter];

export type SpacesHook = SpacesState & SpacesOperations;

const SpacesContext = createContext<SpacesHook | null>(null);

export function useProvideSpaces(): SpacesHook {
	const [spacesState, setSpacesState] = useState<SpacesState>({
		spaces: [],
		activeSpace: null,
		postsForActiveSpace: [],
	});

	const setActiveSpace = async (activeSpace: TechnologySpace) => {
		const posts = await TechSpacesPostsClient.get(activeSpace.identifier);
		setSpacesState({ ...spacesState, activeSpace, postsForActiveSpace: posts });
	};

	const fetchAllSpaces = async () => {
		const spaces = await TechSpacesClient.getAll();
		setSpacesState({ ...spacesState, spaces });
	}

	return {
		...spacesState,
		setActiveSpace,
		fetchAllSpaces
	};
}

export const ProvideSpaces: FunctionComponent = ({ children }) => {
	const spacesHook = useProvideSpaces();

	return <SpacesContext.Provider value={spacesHook}>{children}</SpacesContext.Provider>;
};

export const useSpaces = (): SpacesHook => {
	const spacesHook = useContext(SpacesContext);
	if (spacesHook === null) {
		throw new Error("SpacesContext did not contain the hook- perhaps you didn't provide the SpacesContext?");
	}

	const { spaces, activeSpace, fetchAllSpaces, setActiveSpace } = spacesHook;

	useEffect(() => {
		if (isEmpty(spaces)) {
			fetchAllSpaces();
		}
	}, [spaces, fetchAllSpaces]);

	useEffect(() => {
		if (!activeSpace && !isEmpty(spaces)) {
			setActiveSpace(head(spaces)!);
		}
	}, [spaces, activeSpace, setActiveSpace]);

	return spacesHook;
};
