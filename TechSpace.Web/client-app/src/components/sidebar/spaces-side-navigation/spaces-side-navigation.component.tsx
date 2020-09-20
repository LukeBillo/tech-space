import { TechnologySpace } from '../../../shared/models/technology-space.model';
import { Loading } from '../../../shared/components/loading.component';
import React, { FunctionComponent } from 'react';
import { useSpacesState } from '../../../state/spaces/spaces.context';
import { useActiveSpaceReducer } from '../../../state/active-space/active-space.context';
import { head } from 'lodash';

export const SpacesSideNavigation: FunctionComponent = () => {
    const { spaces } = useSpacesState();
    const { state, dispatch } = useActiveSpaceReducer();

    const setAsActiveSpace = (activeSpace: TechnologySpace) => dispatch({ type: "set_active_space", payload: activeSpace! });

    if (spaces && !state?.activeSpace && spaces.length > 0) {
        const activeSpace = head(spaces);
        setAsActiveSpace(activeSpace!);
    }

	return (
		<div className={'SpacesSideNavigation mx-8 my-2'}>
			<h2>Spaces</h2>
            {spaces ? 
                spaces.map((space) => constructSpaceNavItem(space, space.identifier === state?.activeSpace.identifier, setAsActiveSpace)) : 
                <Loading />}
		</div>
	);
};

export type SpaceNavItemProps = {
    space: TechnologySpace,
    isActive: boolean,
    setAsActiveSpace: (space: TechnologySpace) => void
}

const constructSpaceNavItem = (technologySpace: TechnologySpace, isActive: boolean, setAsActiveSpace: (space: TechnologySpace) => void) => {
	return <SpaceNavItem key={technologySpace.identifier} space={technologySpace} isActive={isActive} setAsActiveSpace={setAsActiveSpace} />;
};

const SpaceNavItem: FunctionComponent<SpaceNavItemProps> = ({ space, isActive, setAsActiveSpace }) => {
    return (
        <div className={"SpaceNavItem pl-4 py-2"}>
            <a href={`#${space.identifier}`} className={"hover:bg-gray cursor-pointer"} onClick={() => setAsActiveSpace(space)}>{space.name}</a>
        </div>
    );
}
