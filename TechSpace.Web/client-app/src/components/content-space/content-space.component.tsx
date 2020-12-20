import React, { FunctionComponent } from 'react';
import { Route, Switch } from 'react-router-dom';
import { RedirectToDefaultSpace } from '../../containers/redirect-to-default-space.container';
import { ActiveSpaceDisplay } from "../../containers/active-space-display.container";
import { ActivePostDisplay } from "../../containers/active-post-display.container";
import { ProvideActiveSpace } from '../../hooks/active-space.context';
import { ProvideActivePost } from "../../hooks/active-post.context";

export const ContentSpace: FunctionComponent = () => {
	return (
		<ProvideActivePost>
			<div className="ContentSpace overflow-y-scroll flex-grow p-2">
				<Switch>
					<Route exact path='/'>
						<RedirectToDefaultSpace />
					</Route>
					<Route path={`/space/:spaceId`}>
						<ActiveSpaceDisplay />
					</Route>
					<Route path={`/:provider/post/:postId`}>
						<ActivePostDisplay />
					</Route>
				</Switch>
			</div>
		</ProvideActivePost>
	);
};
