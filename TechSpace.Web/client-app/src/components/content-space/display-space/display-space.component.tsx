import React, { FunctionComponent } from 'react';
import { useSpaces } from '../../../state/spaces.state';

export const DisplaySpace: FunctionComponent = () => {
	const { spaces, activeSpace } = useSpaces();

	return spaces && activeSpace ? (
		<div className="SpaceDisplay">
			<div className="viewing-title">
				<h2>You're viewing {activeSpace.name}</h2>
			</div>
		</div>
	) : (
		<Loading />
	);
};

const Loading = () => <div>Loading...</div>;
