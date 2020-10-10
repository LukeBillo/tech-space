import { TechnologySpace } from '../../../shared/models/technology-space.model';
import { Loading } from '../../../shared/components/loading.component';
import React, { FunctionComponent } from 'react';
import { head } from 'lodash';
import { useSpaces } from '../../../hooks/spaces.context';

export const SpacesSideNavigation: FunctionComponent = () => {
	const { spaces, activeSpace, setActiveSpace } = useSpaces();

	return (
		<div className={'SpacesSideNavigation mx-8 my-2'}>
			<h2>Spaces</h2>
			{spaces ? (
				spaces.map((space) =>
					constructSpaceNavItem(space, space.identifier === activeSpace?.identifier, setActiveSpace)
				)
			) : (
				<Loading />
			)}
		</div>
	);
};

export type SpaceNavItemProps = {
	space: TechnologySpace;
	isActive: boolean;
	setAsActiveSpace: (space: TechnologySpace) => void;
};

const constructSpaceNavItem = (
	technologySpace: TechnologySpace,
	isActive: boolean,
	setAsActiveSpace: (space: TechnologySpace) => void
) => {
	return (
		<SpaceNavItem
			key={technologySpace.identifier}
			space={technologySpace}
			isActive={isActive}
			setAsActiveSpace={setAsActiveSpace}
		/>
	);
};

const SpaceNavItem: FunctionComponent<SpaceNavItemProps> = ({ space, isActive, setAsActiveSpace }) => {
    const cssClasses = isActive ?
        'hover:bg-gray cursor-pointer active' :
        'hover:bg-gray cursor-pointer';

	return (
		<div className={'SpaceNavItem pl-4 py-2'}>
			<a
				href={`#${space.identifier}`}
				className={cssClasses}
				onClick={() => setAsActiveSpace(space)}
			>
				{space.name}
			</a>
		</div>
	);
};
