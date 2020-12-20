import React, { FunctionComponent } from 'react';
import { Loader } from '../../loading/loader.component';
import { useSpaces } from '../../../../hooks/spaces.context';
import { TechnologySpace } from '../../../../models/technology-space.model';
import { Link } from 'react-router-dom';
import { useActiveSpace } from '../../../../hooks/active-space.context';

export const SpacesSideNavigation: FunctionComponent = () => {
	const { spaces } = useSpaces();
	const { activeSpace, setActiveSpace } = useActiveSpace();

	return (
		<div className={'SpacesSideNavigation mx-8 my-2'}>
			<h2>Spaces</h2>
			{spaces ? (
				spaces.map((space) =>
					constructSpaceNavItem(space, space.identifier === activeSpace?.identifier, setActiveSpace)
				)
			) : (
				<Loader />
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
			<Link
				to={`/space/${space.identifier}`}
				className={cssClasses}
				onClick={() => setAsActiveSpace(space)}
			>
				{space.name}
			</Link>
		</div>
	);
};
