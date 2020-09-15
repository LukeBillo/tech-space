import { TechnologySpace } from '../../../shared/models/technology-space.model';
import { LoadingSpaces } from './loading-spaces.component';
import { SpaceNavItem } from './space-nav-item.component';
import React, { FunctionComponent } from 'react';
import { useSpaces } from '../../../state/spaces.state';

const ConstructSpaceNavItem = (technologySpace: TechnologySpace, isActive: boolean) => {
	return <SpaceNavItem key={technologySpace.identifier} space={technologySpace} isActive={isActive} />;
};

export const SpacesSideNavigation: FunctionComponent = () => {
	const { spaces, activeSpace } = useSpaces();

	return (
		<div className={'SpacesSideNavigation mx-8 my-2'}>
			<h2>Spaces</h2>
			<hr />
			{spaces ? spaces.map((space) => ConstructSpaceNavItem(space, space === activeSpace)) : <LoadingSpaces />}
		</div>
	);
};
