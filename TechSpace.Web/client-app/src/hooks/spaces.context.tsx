import React, { createContext, useState, FunctionComponent, useContext, useEffect } from 'react';
import { TechnologySpace } from '../models/technology-space.model';
import { TechSpacesClient } from '../http/tech-spaces.http';
import { isEmpty } from 'lodash';

export type SpacesState = {
	spaces: TechnologySpace[];
};

export interface SpacesOperations {
	fetchAllSpaces(): Promise<void>;
}

export type SpacesStateSetter = (spacesState: SpacesState) => void;
export type SpacesStateHook = [SpacesState, SpacesStateSetter];

export type SpacesHook = SpacesState & SpacesOperations;

const SpacesContext = createContext<SpacesHook | null>(null);

export function useProvideSpaces(): SpacesHook {
	const [spacesState, setSpacesState] = useState<SpacesState>({
		spaces: [],
	});

	const fetchAllSpaces = async () => {
		const spaces = await TechSpacesClient.getAll();
		setSpacesState({ ...spacesState, spaces });
	}

	return {
		...spacesState,
		fetchAllSpaces,
	};
}

export const ProvideSpaces: FunctionComponent = ({ children }) => {
	const spacesHook = useProvideSpaces();

	return (
		<SpacesContext.Provider value={spacesHook}>
			{children}
		</SpacesContext.Provider>);
};

export const useSpaces = (): SpacesHook => {
	const spacesHook = useContext(SpacesContext);
	if (spacesHook === null) {
		throw new Error("SpacesContext did not contain the hook- perhaps you didn't provide the SpacesContext?");
	}

	const { spaces, fetchAllSpaces } = spacesHook;

	useEffect(() => {
		if (isEmpty(spaces)) {
			fetchAllSpaces();
		}
	}, [spaces, fetchAllSpaces]);

	return spacesHook;
};
