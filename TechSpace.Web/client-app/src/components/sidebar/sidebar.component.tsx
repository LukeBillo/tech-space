import React, { FunctionComponent } from 'react';
import { SpacesContextProvider } from '../../state/spaces/spaces.context';
import './sidebar.css';
import { SpacesSideNavigation } from './spaces-side-navigation/spaces-side-navigation.component';

export const SideBar: FunctionComponent = () => {
	return (
		<SpacesContextProvider>
			<div className={'SideBar bg-secondary-light max-h-screen'}>
				<div className="logo-with-title">
					<h1>TechSpace</h1>
				</div>
					<SpacesSideNavigation/>
			</div>
		</SpacesContextProvider>
	);
};
