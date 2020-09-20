﻿import React, { FunctionComponent } from 'react';
import { Loading } from '../../shared/components/loading.component';
import { TechnologySpace } from '../../shared/models/technology-space.model';
import { useActiveSpaceReducer } from '../../state/active-space/active-space.context';
import { useSpacesState } from '../../state/spaces/spaces.context';

export const ContentSpace = () => {
	const { spaces } = useSpacesState();
	const { state, dispatch } = useActiveSpaceReducer();

	if (state === null) {
		return (<Loading />)
	}

	const { activeSpace, posts } = state;

	return (
		<div className="ContentSpace p-2">
			{spaces && activeSpace ? <ActiveSpaceDisplay activeSpace={activeSpace} /> : <Loading />}
		</div>
	);
};

type ActiveSpaceProps = {
	activeSpace: TechnologySpace;
};

const ActiveSpaceDisplay: FunctionComponent<ActiveSpaceProps> = ({ activeSpace }) => {
	return (
		<div className="SpaceDisplay p-3">
			<div className="viewing-title">
				<h4>You're viewing...</h4>
				<h2>{activeSpace.name}</h2>
			</div>
			<div className="space-posts"></div>
		</div>
	);
};
