import React, { createContext, useState, FunctionComponent, useContext } from 'react';
import { TechnologySpacePost } from '../models/technology-space-post.model';

export type ActivePostState = {
	activePost: TechnologySpacePost | null;
};

export interface ActivePostOperations {
	setActivePost(activePost: TechnologySpacePost): void;
}

export type ActivePostStateSetter = (spacesState: ActivePostState) => void;
export type ActivePostStateHook = [ActivePostState, ActivePostStateSetter];

export type ActivePostHook = ActivePostState & ActivePostOperations;

const ActivePostContext = createContext<ActivePostHook | null>(null);

export function useProvideActivePost(): ActivePostHook {
	const [activePostState, setActivePostState] = useState<ActivePostState>({
		activePost: null,
	});

	const setActivePost = (post: TechnologySpacePost) => {
        setActivePostState({ ...activePostState, activePost: post });
    };

	return {
		...activePostState,
		setActivePost,
	};
}

export const ProvideActivePost: FunctionComponent = ({ children }) => {
	const activePostHook = useProvideActivePost();

	return (
		<ActivePostContext.Provider value={activePostHook}>
			{children}
		</ActivePostContext.Provider>);
};

export const useActivePost = (): ActivePostHook => {
    const activePostHook = useContext(ActivePostContext);
    
	if (activePostHook === null) {
		throw new Error("ActivePostContext did not contain the hook- perhaps you didn't provide the ActiveSpaceContext?");
	}

	return activePostHook;
};
